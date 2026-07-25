# How to Validate MVC Models using DataAnnotation Attributes

Companion sample for the GeeksArray tutorial
[How to Validate MVC Models using DataAnnotation Attributes](https://geeksarray.com/blog/how-to-validate-mvc-model-using-dataannotation-attributes).

**Start here for this article:** `Models/Supplier.cs` — Required, StringLength, Range, EmailAddress, RegularExpression, and Url attributes; POST an invalid body to `/api/suppliers` and the framework answers 400 problem+json before any action code runs.

## What's inside

A single .NET 10 MVC application (`GeekStore.Mvc`) shared by several GeeksArray
tutorials — each area of the app demonstrates one article's topic:

| Route / file | Demonstrates | Article |
|---|---|---|
| `/Products` | model → controller → view page | [Getting Started with ASP.NET Core MVC](https://geeksarray.com/blog/getting-started-with-aspnet-mvc-core-and-dotnet5) |
| `/Demo/AsJson`, `/Demo/AsText`, `/Demo/Missing`, `/Demo/Teapot`, `/Demo/Moved` | every action result type with its real status code | [Action Methods & Action Results](https://geeksarray.com/blog/asp-net-mvc-core-controller-action-method-and-types-of-action-result) |
| `/Demo/DownloadBytes`, `/Demo/DownloadStream` | FileContentResult / FileStreamResult with proper headers | [Returning Files with FileResult](https://geeksarray.com/blog/aspnet-core-mvc-returning-file-using-fileresult) |
| `/Demo/FromQuery`, `/Demo/PostForm`, `/Demo/PostBody`, `/demo/route-bind/{id}` | every model-binding source | [Model Binding](https://geeksarray.com/blog/aspnet-core-mvc-model-binding) |
| `/api/suppliers` (GET/POST/PUT/DELETE) | full CRUD with automatic DataAnnotations validation | [CRUD Operations](https://geeksarray.com/blog/crud-operations-using-aspnetcore) · [Model Validation](https://geeksarray.com/blog/how-to-validate-mvc-model-using-dataannotation-attributes) |
| `/Catalog` | JSON endpoints, cascading dropdowns, autocomplete with fetch | [Cascading Dropdowns](https://geeksarray.com/blog/cascading-dropdownlist-example-using-jsonresult-in-asp-net-mvc) · [Autocomplete](https://geeksarray.com/blog/jquery-ajax-autocomplete-in-asp-net-mvc-core) |

## Run it

```bash
dotnet run
```

Open the printed localhost URL and browse the routes above, or exercise the API:

```bash
curl -X POST http://localhost:<port>/api/suppliers \
  -H "Content-Type: application/json" \
  -d '{"name":"Geek Supplies","contactEmail":"geek@supplies.com","rating":5}'
# → 201 Created with Location header

curl -X POST http://localhost:<port>/api/suppliers \
  -H "Content-Type: application/json" -d '{"name":"x","rating":9}'
# → 400 problem+json with per-field validation errors
```

Every response shown in the articles came from running exactly this code.
