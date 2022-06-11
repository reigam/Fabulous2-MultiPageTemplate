namespace Fab2Demo

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms
open Fabulous.XamarinForms

module AppPages =
    type Name = Name of string
    let nameValue (Name str) = str
    type Names = {
        TemplatePage: Name
        LayoutsPage: Name
        FirstPage: Name
        SecondPage: Name
        ThirdPage: Name
    }
    let names: Names = {
        TemplatePage = Name "Template Page"
        LayoutsPage = Name "Layouts Page"
        FirstPage = Name "First Page"
        SecondPage = Name "Second Page"
        ThirdPage = Name "Third Page"
    }
        
type GlobalModel = { 
    PageStash: List<AppPages.Name>
    }

module Helpers = 
    let rec reshuffle list: List<'a> =
        match list with
        | [] -> []
        | l -> l |> List.rev |> List.tail |> List.rev
        
[<Extension>]
type MyExtensions =
    [<Extension>]
    static member inline blueStyle(this: WidgetBuilder<'msg, #IVisualElement>) =
          this.verticalOptions(LayoutOptions.Center)
              .horizontalOptions(LayoutOptions.Center)
              .margin(20.)
              .backgroundColor(Color.Red.ToFabColor())
              
    [<Extension>]
    static member inline redStyle(this: WidgetBuilder<'msg, #IVisualElement>) =
          this.verticalOptions(LayoutOptions.Start)
              .horizontalOptions(LayoutOptions.Start)
              .margin(40.)
              .backgroundColor(Color.Blue.ToFabColor())
              
    [<Extension>]
    static member inline myStyle(this: WidgetBuilder<'msg, #IVisualElement>, i)=
        let x j =
            match j with
            | 1 -> this.verticalOptions(LayoutOptions.Start)
                        .horizontalOptions(LayoutOptions.Start)
                        .margin(40.)
                        .backgroundColor(Color.Blue.ToFabColor())                
            | 2 -> this.verticalOptions(LayoutOptions.Start)
                        .horizontalOptions(LayoutOptions.Start)
                        .margin(40.)
                        .backgroundColor(Color.Red.ToFabColor())
            | _ -> this
               
        match box this with
        | :? WidgetBuilder<'msg, IButton> -> x i
        | :? WidgetBuilder<'msg, ILabel> ->
            this.verticalOptions(LayoutOptions.Start)
                .horizontalOptions(LayoutOptions.Start)
                .margin(40.)
                .backgroundColor(Color.Green.ToFabColor())                
        | _ -> this
              
//        /// TODO Rearange
//        /// match i
//        ///     match box this

        

        


