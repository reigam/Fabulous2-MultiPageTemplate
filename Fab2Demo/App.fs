namespace Fab2Demo

open Fab2Demo
open Fabulous
open Xamarin.Forms
open Fabulous.XamarinForms

open type View

module App =
    type Model = {
        Global: GlobalModel
        FirstPage: FirstPage.Model
        SecondPage: SecondPage.Model
        ThirdPage: ThirdPage.Model
    }

    type Msg =
        | FirstPageMsg of FirstPage.Msg
        | SecondPageMsg of SecondPage.Msg
        | ThirdPageMsg of ThirdPage.Msg
        | NavigationPopped

    let initModel = 
        { Global = { 
            PageStash = [AppPages.names.FirstPage] }
          FirstPage = FirstPage.init()
          SecondPage = SecondPage.init()
          ThirdPage = ThirdPage.init()
        }
          
    let init () = initModel

    let update msg model =
        match msg with
        | FirstPageMsg m ->
            let l, g = FirstPage.update m model.FirstPage model.Global
            { model with FirstPage = l; Global = g }       
        | SecondPageMsg m ->
            let l, g = SecondPage.update m model.SecondPage model.Global
            { model with SecondPage = l; Global = g }       
        | ThirdPageMsg m ->
            let l, g = ThirdPage.update m model.ThirdPage model.Global
            { model with ThirdPage = l; Global = g }   
        | NavigationPopped ->
            { model with Global = { PageStash = Helpers.reshuffle model.Global.PageStash } }

    let view (model: Model) =
        Application(
            (NavigationPage(){                
                for page in model.Global.PageStash do
                    match page with
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
                .onPopped(NavigationPopped)
        )

    let program = Program.stateful init update view
