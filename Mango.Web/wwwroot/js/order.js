var dataTable;

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: "/order/getall" },
        "columns": [
            { data: 'orderheaderid', "width": "5%"},
            { data: 'email', "width": "25%"}
        ]
    })
}