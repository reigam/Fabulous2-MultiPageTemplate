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
        | SelectedIndexChanged of int 

    let initModel = {
        Title = thisPage
        Style = 0
    }

    let init() = initModel, Cmd.none

    let update msg (model: Model) (globalModel: GlobalModel) =
        match msg with
        | Close -> model, { globalModel with PageStash = [thisPage] }, Cmd.none
        | ChangeStyle -> { model with Style = Helpers.changeStyle (model.Style) }, globalModel, Cmd.none
        | SelectedIndexChanged i -> model, globalModel, Cmd.none
        

    let view (model: Model) (globalModel: GlobalModel)  =        
   
        (ContentPage (
            (model.Title |> AppPages.nameValue),
            VStack() {
                Picker([
                    "Layout 1"
                    "Layout 2"
                ], 0, SelectedIndexChanged)
                    .myStyle(model.Style)
                
                    
            }
        ))
            .toolbarItems() {
                ToolbarItem("test", ChangeStyle)
            }
           