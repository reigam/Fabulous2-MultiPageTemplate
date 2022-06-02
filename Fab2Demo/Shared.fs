namespace Fab2Demo

open Xamarin.Forms
open Fabulous.XamarinForms

module AppPages =
    type Name = Name of string
    let nameValue (Name str) = str
    type Names = {
        TemplatePage: Name
        FirstPage: Name
        SecondPage: Name
        ThirdPage: Name
    }
    let names: Names = {
        TemplatePage = Name "Template Page"
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