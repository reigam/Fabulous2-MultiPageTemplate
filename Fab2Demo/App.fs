namespace Fab2Demo

open Fab2Demo
open Fabulous
open Xamarin.Forms
open Fabulous.XamarinForms

open type View

module App =
    type Model = {
        Global: GlobalModel
        StartPage: StartPage.Model
    }

    type Msg =
        | StartPageMsg of StartPage.Msg
        | NavigationPopped

    let initModel = 
        { Global = { 
            PageStash = [AppPages.names.StartPage] }
          StartPage = StartPage.init()
        }
          
    let init () = initModel

    let update msg model =
        match msg with
        | StartPageMsg m ->
            let l, g = StartPage.update m model.StartPage model.Global
            { model with StartPage = l; Global = g }
        | NavigationPopped ->
            { model with Global = { PageStash = Helpers.reshuffle model.Global.PageStash } }

    let view (model: Model) =
        let p = View.map StartPageMsg (StartPage.view model.StartPage model.Global)
        let q =
            ContentPage(
                "Fabulous2.0 Demo",
                VStack() {
                    Label("Test")
                        .centerTextHorizontal()
                }
            )
        Application(
            (NavigationPage(){
                q
                p
            })
                .onPopped(NavigationPopped)
        )

    let program = Program.stateful init update view
