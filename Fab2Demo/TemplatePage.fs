namespace Fab2Demo

open Fab2Demo
open Fabulous
open Xamarin.Forms
open Fabulous.XamarinForms

open type View

module TemplatePage =
    let thisPage = AppPages.names.TemplatePage
    
    type Model = { 
        Title: AppPages.Name 
    }
      
    type Msg =
        | Close

    let initModel = { Title = thisPage }

    let init() = initModel

    let update msg (model: Model) (globalModel: GlobalModel) =
        match msg with
        | Close -> model, { globalModel with PageStash = [thisPage] }

    let view (model: Model) (globalModel: GlobalModel)  =
        ContentPage (
            (model.Title |> AppPages.nameValue),
            VStack() {
                Button("Do Something", Close)
            }
        )
            
//            content = View.StackLayout (
//                verticalOptions = LayoutOptions.Center,
//                children = [
//                    View.Button (
//                        text = "Back to start page",
//                        command = (fun () -> dispatch (Close)),
//                        horizontalOptions = LayoutOptions.Center) ]))