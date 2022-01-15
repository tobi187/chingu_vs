//namespace MeteoriteBackEnd
namespace DataAction

open System
open FSharp.Control
open System.Net.Http
open System.Net.Http.Json
open MeteroiteBackEnd.MeteoriteApiModel

module DataAccess =
    let client = new HttpClient()

    let checkNull (x:APIModel) =
        if not <| Object.ReferenceEquals(x.geoLocation, null)
            then x
            else 
                {name=x.name; id=x.id; nametype=x.nametype; recclass=x.recclass; mass=x.mass; fall=x.fall; year=x.year; reclat=x.reclat; reclong=x.reclong; geoLocation={latitude="";longitude=""}}
    
    let getRequest () = 
        task {
            let! res = client.GetAsync("https://data.nasa.gov/resource/gh4g-9sfh.json")
            let! data = res.Content.ReadFromJsonAsync<APIModel[]>()
            (*match res.IsSuccessStatusCode with 
            | true -> return Ok data
            | false -> return Error data*)
            match res.IsSuccessStatusCode with
            | true ->
                let correctData = 
                    Seq.ofArray data 
                    |> Seq.sortBy (fun x -> x.name)
                    |> Seq.map checkNull

                return correctData
            | false -> 
                let err: seq<APIModel> = Seq.empty 
                return err
        }

    let searchUser (userName:string) = 
        getRequest()
        |> Async.AwaitTask
        |> Async.RunSynchronously
        |> Seq.where (fun x -> x.name.ToLower().StartsWith (userName.ToLower()))
        |> Seq.sortBy (fun x -> x.name)