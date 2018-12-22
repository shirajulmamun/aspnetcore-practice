
$('#searchButton').click(function() {
    var searchCriteria = getSearchCriteria();
    search(searchCriteria);

});

function getSearchCriteria() {
    var name = $('#Name').val();
    var regNo = $('#RegNo').val();

    return { Name: name, RegNo: regNo };
}

function search(searchCriteria) {

    if ($.fn.DataTable.isDataTable("#tbEmployee")) {
        var table = $("#tbEmployee").DataTable();
        table.destroy();
    }

    var jsonData = JSON.stringify(searchCriteria);

    $('#tbEmployee').DataTable({
        serverSide:true,
        ajax: {
            url: "/Employee/EmployeeSearch",
            type: "POST",
            data: { searchCriteria: searchCriteria },
            dataSrc: ""
           


        },

        columns: [
            { data: "name" },
            { data: "regNo" },
            { data: "salary" },
            {
                data: "department",
                render: function(data) {
                    if (data == undefined || data == null) {
                        return "N/A";
                    } else {
                        return data.name;
                    }
                }
            }
        ]
    });
}


