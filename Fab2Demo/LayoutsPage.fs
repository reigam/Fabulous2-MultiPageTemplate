namespace Fab2Demo

open Fab2Demo
open Fabulous
open Xamarin.Forms
open Fabulous.XamarinForms

open type View

module LayoutsPage =
    let thisPage = AppPages.names.LayoutsPage
    
    type Model = { 
        Title: AppPages.Name
        Style: int
    }
      
    type Msg =
        | Close
        | ChangeStyle

    let initModel = {
        Title = thisPage
        Style = 0
    }

    let init() = initModel, Cmd.none

    let update msg (model: Model) (globalModel: GlobalModel) =
        match msg with
        | Close -> model, { globalModel with PageStash = [thisPage] }, Cmd.none
        | ChangeStyle ->
            let i =
                match model.Style with
                | 1 -> 2
                | 2 -> 3
                | _ -> 1
            { model with Style = i},
            globalModel, Cmd.none

    let view (model: Model) (globalModel: GlobalModel)  =        
   
        (ContentPage (
            (model.Title |> AppPages.nameValue),
            VStack() {
                Button("ChangeStyle", ChangeStyle).myStyle(model.Style)
                Label("Something").myStyle(model.Style)
            }
        ))
            .toolbarItems() {
                ToolbarItem("test", ChangeStyle)
            }
           