module HelloWorld.Program

open Falco
open Falco.Routing
open Falco.HostBuilder
open Microsoft.AspNetCore.Builder

let handle code message = Response.withStatusCode code >> Response.ofPlainText message
let exceptionHandler = handle 500 "Woops!"

[<EntryPoint>]
let main args =
    webHost args {
        use_if    FalcoExtensions.IsDevelopment DeveloperExceptionPageExtensions.UseDeveloperExceptionPage
        use_ifnot FalcoExtensions.IsDevelopment (FalcoExtensions.UseFalcoExceptionHandler exceptionHandler)
        
        endpoints [ 
            get "/" (Response.ofPlainText "Hello F# Azure")
            get "/hi" (Response.ofPlainText "Why hello there")
        ]
    }
    0