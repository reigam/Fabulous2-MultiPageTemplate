namespace Fab2Demo

open Fab2Demo
open Fabulous
open Xamarin.Forms
open Fabulous.XamarinForms

open type View

module App =
    type Model = {
        Global: GlobalModel
        LayoutsPage: LayoutsPage.Model
        FirstPage: FirstPage.Model
        SecondPage: SecondPage.Model
        ThirdPage: ThirdPage.Model
    }

    type Msg =
        | LayoutsPageMsg of LayoutsPage.Msg
        | FirstPageMsg of FirstPage.Msg
        | SecondPageMsg of SecondPage.Msg
        | ThirdPageMsg of ThirdPage.Msg
        | NavigationPopped

    let initModel = 
        { Global = { 
            PageStash = [AppPages.names.FirstPage] }
          LayoutsPage = fst (LayoutsPage.init())
          FirstPage = fst (FirstPage.init())
          SecondPage = fst (SecondPage.init())
          ThirdPage = fst (ThirdPage.init())
        }
          
    let init () = initModel, Cmd.none

    let update msg model =
        match msg with
        | LayoutsPageMsg m ->
            let l, g, c = LayoutsPage.update m model.LayoutsPage model.Global
            { model with LayoutsPage = l; Global = g }, (Cmd.map LayoutsPageMsg c)       
        | FirstPageMsg m ->
            let l, g, c = FirstPage.update m model.FirstPage model.Global
            { model with FirstPage = l; Global = g }, (Cmd.map FirstPageMsg c)       
        | SecondPageMsg m ->
            let l, g, c = SecondPage.update m model.SecondPage model.Global
            { model with SecondPage = l; Global = g }, (Cmd.map SecondPageMsg c)       
        | ThirdPageMsg m ->
            let l, g, c = ThirdPage.update m model.ThirdPage model.Global
            { model with ThirdPage = l; Global = g },  (Cmd.map ThirdPageMsg c)       
        | NavigationPopped ->
            { model with Global = { PageStash = Helpers.reshuffle model.Global.PageStash } }, Cmd.none

    let view (model: Model) =
        Application(
            (NavigationPage(){
                for page in model.Global.PageStash do
                    match page with                                  
                    |AppPages.Name "Layouts Page" ->
                        let p = View.map LayoutsPageMsg (LayoutsPage.view model.LayoutsPage model.Global)
                        yield p     
                    |AppPages.Name "First Page" ->
                        let p = View.map FirstPageMsg (FirstPage.view model.FirstPage model.Global)
                        yield p 
                    |AppPages.Name "Second Page" ->
                        let p = View.map SecondPageMsg (SecondPage.view model.SecondPage model.Global)
                        yield p 
                    |AppPages.Name "Third Page" ->
                        let p = View.map ThirdPageMsg (ThirdPage.view model.ThirdPage model.Global)
                        yield p 
                    | _ -> ()
            })
                .onBackNavigated(NavigationPopped)
                .hasNavigationBar(true)

        )

    let program = Program.statefulWithCmd init update view
