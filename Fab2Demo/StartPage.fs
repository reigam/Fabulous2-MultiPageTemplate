namespace Fab2Demo

open Xamarin.Forms
open Fabulous.XamarinForms

open type View

module StartPage =
    let thisPage = AppPages.names.StartPage
    
    type Model = {
        Title: AppPages.Name
    }
    
    type Msg =
        | OpenPage of AppPages.Name
        
    let initModel = {
        Title = thisPage
    }
    
    let init() = initModel
    
    let update msg (model: Model) (globalModel: GlobalModel) =
            match msg with
            | OpenPage s -> model, {globalModel with PageStash = List.append globalModel.PageStash [s]}
            
    let view (model: Model) (globalModel: GlobalModel) =
        Application(
            ContentPage(
                "Fabulous2.0 Demo",
                VStack() {
                    Label("Test")
                        .centerTextHorizontal()
                }
            )
        )
        
