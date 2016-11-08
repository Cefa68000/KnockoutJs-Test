var carDataArray = [];
function HomeViewModel() {
    var self = this;
    self.companyCars = ko.observableArray(carDataArray);
    self.timeOutDuration = ko.observable(1000).extend({ number: true });

    self.filterStatus = ko.observable();
    self.companyAll = ko.observableArray();
    self.selectedCustomerCarId = ko.observable();

    function getCars() {
        $.getJSON("/api/Me/GetCompanyCars",
            {
                companyCarId: self.selectedCustomerCarId(),
                filterStatus: self.filterStatus() 
            },
            function (data) {
                var duration = self.timeOutDuration();

                if (!isNumeric(duration))
                    duration = 1000;

                //Only set once clone cars array
                if (self.companyAll().length === 0) {
                    self.companyAll($.map(data, function(element) {
                         return {
                             id: element.id,
                             name: element.name
                         }
                    }));
                }
                self.companyCars(data);
                setTimeout(getCars, duration );
            });
    }

    function isNumeric(n) {
        return !isNaN(parseFloat(n)) && isFinite(n);
    }

    getCars();
}

ko.applyBindings(new HomeViewModel());
