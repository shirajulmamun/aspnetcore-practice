

$('#tbEmployee').dataTable({
    ajax: {
        url: "/Employee/GetAllEmployee",
        type: "POST",
        contentType:"application/json",
        dataSrc:""
    } ,
    columns: [
        { data: "name" },
        { data: "regNo" },
        { data: "salary" },
        {data:"department.name"}

    ]
});