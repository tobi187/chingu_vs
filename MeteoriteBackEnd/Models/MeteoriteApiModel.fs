namespace MeteroiteBackEnd.MeteoriteApiModel

[<CLIMutable>]
type GeoLocation = {
    latitude: string
    longitude: string
}


[<CLIMutable>]
type APIModel= {
    name: string
    id: string
    nametype: string
    recclass: string
    mass: string
    fall: string
    year: string
    reclat: string
    reclong: string
    geoLocation: GeoLocation
}


[<CLIMutable>]
type WebModel= {
    name: string
    id: string
    nametype: string
    recclass: string
    mass: string
    fall: string
    year: string
    reclat: string
    reclong: string
    geoLat: string
    geoLang: string
}
