/// <reference path="../Scripts/jquery-1.7.2.min.js" />
/// <reference path="../Scripts/knockout-2.1.0.js" />

//Connect these ViewModels with the Views. 
//Use the ko.applyBindings() method by specifying the Id’s of the div tags that we used in the Suppliers.cshtml file.

$(document).ready(function () {
    ko.applyBindings(new supplierVM(), document.getElementById('displayNode'));
});

//With supplier object having 3 properties
function supplier(name, id, address) {
    var self = this;

    self.Id = id;
    self.Name = name;
    self.Address = address;
}

function supplierVM() {
    var self = this;

    // cerate list (array) of suppliers
    // make it observableArray from the Knockout library
    //changes to this array will result in automatic notifications to any UI elements that are bound to it
    self.suppliers = ko.observableArray([]);

     self.getSuppliers = function () {
         self.suppliers.removeAll();

         //getJSON call to the HTTP service and getting the list of all suppliers and populating the observableArray.
         //getJSON uses the controller supplier which implemnets the web api interface
         //This is collection is bounded to in the SuppliersList.cshtml’s tbody tag
             $.getJSON("/api/supplier/", function (data) {
            $.each(data, function (key, val) {
                self.suppliers.push(new supplier(val.Name, val.Id, val.Address));
                 });
          });
       };
}

