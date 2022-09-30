


async function Create() {
    let text = "";
    text = `
        <div class="addselection">
            <div class="row">
                        <div class="col">
                            <form id="Create" method="POST" action="javascript:void(0);">
                                <div  class="text-danger"></div>
                                <input type="hidden" asp-for="Id" />
                                <div class="form-group">
                                    <label class="control-label">Name</label>
                                    <input class="form-control" name="Name" />
                                   
                                </div>
                                <div class="form-group">
                                    <label  class="control-label">Locations</label>

                                    <select class="form-control" name="Location_Id" id="LocationCreate"></select>

                                </div>
                                <div class="form-group">
                                    <input type="submit" value="Save" class="btn btn-primary" />
                                </div>
                            </form>
                        </div>
                    </div>
        </div
    `;
    $("#ModalTitle").text("Create");
    $("#ModalBody").html(text);

    const Locations = await GetAll("Locations");
    $("#LocationCreate").empty()
    $.each(Locations, function () {
        $("#LocationCreate").append($("<option />").val(this.id).text(this.name));

    });
    $("#Create").on("submit", async function (event) {
        var data = {};
        data["Id"] = 0;
        $('#Create').serializeArray().map(function (x) { data[x.name] = x.value; });
        const resultPost = await Post("Departments", data);
        console.log(data);
        console.log(resultPost);
        if (resultPost == 200) {
            $('#tDepartments').DataTable().ajax.reload();
            $('#ModalData').modal('hide');
        }
        swal(
            'Success',
            'Data Telah Ditambahkan',
            'success'
        )
        event.preventDefault();

    });
};

async function Edit(id) {

    let departmentDetail = await Get("Departments", {
        "id": id
    });
    let text = "";
    text = `
        <div class="addselection">
            <div class="row">
                        <div class="col">
                            <form id="Edit" method="POST" action="javascript:void(0);">
                                <div  class="text-danger"></div>
                                <input type="hidden" asp-for="Id" />
                                <div class="form-group">
                                    <label  class="control-label">Name</label>
                                    <input class="form-control" name="Name" value="${departmentDetail.name}" />
                                    
                                </div>
                                <div class="form-group">
                                    <label  class="control-label">Locations</label>
                                    
                                    <select class="form-control" name="Location_Id" id="LocationsEdit"></select>
                                    
                                </div>
                                <div class="form-group">
                                    <input type="submit" value="Save" class="btn btn-primary" />
                                </div>
                            </form>
                        </div>
                    </div>
        </div
        
    `

    $("#ModalTitle").text("Edit");
    $("#ModalBody").html(text);
    const Locations = await GetAll("Locations");
    $("#LocationsEdit").empty()
    $.each(Locations, function () {
        if (this.id == departmentDetail.region_Id) {
            $('#LocationsEdit').append(`<option value="${this.id}" selected="selected">${this.name}</option>`);
        }
        else {
            $("#LocationsEdit").append($("<option />").val(this.id).text(this.name));
        }

    });
    $("#Edit").on("submit", async function (event) {
        var data = {};
        data["Id"] = departmentDetail.id;
        $('#Edit').serializeArray().map(function (x) { data[x.name] = x.value; });
        const resultPut = await Put("Departments", data);
        console.log(data);
        console.log(resultPut);
        if (resultPut == 200) {
            $('#tDepartments').DataTable().ajax.reload();
            $('#ModalData').modal('hide');
        }
        swal(
            'Success',
            'Data Telah Berubah',
            'success'
        )
        event.preventDefault();

    });
   
    
};
async function Detail(id) {
    
    let departmentDetail = await Get("Departments", {
        "id": id
    });
    let text = "";
    text = `
        <div class="row">
            <div class="col">
                Name
            </div>
            <div class="col">
                ${departmentDetail.name}
            </div>
        </div>
        <div class="row">
            <div class="col">
                Locations
            </div>
            <div class="col">
               ${departmentDetail.locations.streetAddress}
            </div>
        </div>
    
    `;
    $("#ModalTitle").text("Details");
    $("#ModalBody").html(text);
};


$(document).ready(function () {

    $('#tDepartments').DataTable({

        dom: "<'row'<'col'l><'col'B><'col'f>>"
            + "<'row'<'col-sm-12'tr>>"
            + "<'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7'p>>"
        //dom: 'lBfrtip'
        ,
        buttons: [

            {
                extend: 'excelHtml5',
                name: 'excel',
                title: 'Departments',
                sheetName: 'Departments',
                text: 'download',
                className: 'btn-default',
                filename: 'DataDepartments',
                autoFilter: true,
                exportOptions: {
                    columns: [0, 1]
                }
            }
        ],
        "ajax": {
            type: 'GET',
            url: `/Departments/GetAll`,
            dataSrc: "",
            dataType: "JSON"
        },
        "columns": [
            {
                "data": null,
                "render": function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
            { "data": "name" },
            {
                "data": null,
                "render": function (data, type, row) {
                    return row.locations.streetAddress;
                }
            },
            {
                "data": "",
                "render": function (data, type, row) {
                    return `
                        <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#ModalData" onclick="Edit('${row.id}')">Edit</button>
                        <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#ModalData" onclick="Detail('${row.id}')">Detail</button>
                        <button type="button" class="btn btn-primary" onclick="confirmDelete('tDepartments','Departments',${row.id})">Delete</button>
                    `;
                }
            }
        ]
    });
    

    // Example starter JavaScript for disabling form submissions if there are invalid fields
    (function () {
        'use strict'

        // Fetch all the forms we want to apply custom Bootstrap validation styles to
        var forms = document.querySelectorAll('.needs-validation')
        //$("#contact-form").validator();
        // Loop over them and prevent submission
        Array.prototype.slice.call(forms)
            .forEach(function (form) {
                form.addEventListener('submit', function (event) {
                    if (!form.checkValidity()) {
                        swal(
                            'Error!',
                            'You clicked the <b style="color:red;">error</b> button!',
                            'error'
                        )
                        event.preventDefault()
                        event.stopPropagation()
                    }
                    form.classList.add('was-validated')
                }, false)
            })
        $("#contact-form").on("submit", function (e) {
            // if the validator does not prevent form submit
            if (!e.isDefaultPrevented()) {
                swal(
                    'Success',
                    'You clicked the <b style="color:green;">Success</b> button!',
                    'success'
                )
            }
        });
    })();
});