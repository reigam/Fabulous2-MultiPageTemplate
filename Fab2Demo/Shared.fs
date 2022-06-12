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
    static member inline firstStyle(this: WidgetBuilder<'msg, #IVisualElement>) =
          this.verticalOptions(LayoutOptions.Start)
              .horizontalOptions(LayoutOptions.Start)
              .backgroundColor(Color.Blue.ToFabColor())
              
    [<Extension>]
    static member inline secondStyle(this: WidgetBuilder<'msg, #IVisualElement>) =
              this.margin(80.)
    
    [<Extension>]
    static member inline myStyle(this: WidgetBuilder<'msg, #IVisualElement>, styleID)=
        match styleID with
        | 1 -> match box this with
                | :? WidgetBuilder<'msg, IButton> -> 
                    this.firstStyle()
                        .secondStyle()
                | :? WidgetBuilder<'msg, ILabel> ->
                    this.verticalOptions(LayoutOptions.Start)
                        .horizontalOptions(LayoutOptions.Start)
                        .margin(40.)
                        .backgroundColor(Color.Green.ToFabColor())                
                | _ -> this                  
        | 2 -> match box this with
                | :? WidgetBuilder<'msg, IButton> ->
                    this.verticalOptions(LayoutOptions.End)
                        .horizontalOptions(LayoutOptions.End)
                        .margin(20.)
                        .backgroundColor(Color.Green.ToFabColor())    
                | :? WidgetBuilder<'msg, ILabel> ->
                    this.verticalOptions(LayoutOptions.Start)
                        .horizontalOptions(LayoutOptions.Start)
                        .margin(40.)
                        .backgroundColor(Color.Green.ToFabColor())                
                | _ ->
                    printfn "no valid IView found. Fall back to normal style"
                    this            
        | _ ->
            printfn "no valid StyleID selected. Fall back to normal style"
            this           

              

        

        


