namespace Fab2Demo

open Fab2Demo
open Fabulous
open Xamarin.Forms
open Fabulous.XamarinForms

open type View

module ThirdPage =
    let thisPage = AppPages.names.ThirdPage
    
    type Model = { 
        Title: AppPages.Name 
    }
      
    type Msg =
        | OpenPage of AppPages.Name
        | Close

    let initModel = { Title = thisPage }

    let init() = initModel

    let update msg (model: Model) (globalModel: GlobalModel) =
        match msg with
        | OpenPage s -> model, { globalModel with PageStash = List.append globalModel.PageStash [s] }
        | Close -> model, { globalModel with PageStash = [AppPages.names.FirstPage] }

    let view (model: Model) (globalModel: GlobalModel)  =
        ContentPage (
            (model.Title |> AppPages.nameValue),
            VStack() {
                Button("Close All", Close)
            }
        )