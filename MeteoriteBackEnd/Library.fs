﻿//namespace MeteoriteBackEnd
namespace DataAction

open System
open FSharp.Control
open System.Net.Http
open System.Net.Http.Json
open MeteroiteBackEnd.MeteoriteApiModel

module DataAccess =
    let client = new HttpClient()
    
    let getRequest () = 
        task {
            let! res = client.GetAsync("https://data.nasa.gov/resource/gh4g-9sfh.json")
            let! data = res.Content.ReadFromJsonAsync<APIModel[]>()
            (*match res.IsSuccessStatusCode with 
            | true -> return Ok data
            | false -> return Error data*)
            printfn "%A" data
            return data 
        }