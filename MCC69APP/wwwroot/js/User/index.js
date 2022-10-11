


async function Create() {
    //console.log("Test masuk create")

    let text = "";
    text = `
        <div class="addselection">
            <div class="row">
                        <div class="col">
                            <form id="Create" method="POST" action="javascript:void(0);">
                                <div  class="text-danger"></div>
                                <input type="hidden" asp-for="Id" />
                                <div class="form-group">
                                    <label  class="control-label">Name</label>
                                    <select  class="form-control" name="Id" id="EmployeeCreate"></select
                                </div>
                                <div class="form-group">
                                    <label class="control-label">UserName</label>
                                    <input class="form-control" name="UserName"/>
                                   
                                </div>
                                <div class="form-group">
                                    <label class="control-label">Password</label>
                                    <input class="form-control" name="Password"/>
                                   
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

    
    const Employees = await GetAll("Employees");
    $("#EmployeeCreate").empty()
    $.each(Employees, function () {
        $("#EmployeeCreate").append($("<option />").val(this.id).text(`${this.firstName} ${this.lastName}`));

    });
    $("#Create").on("submit", async function (event) {
        var data = {};
        $('#Create').serializeArray().map(function (x) { data[x.name] = x.value; });
        const resultPost = await Post("User", data);
        console.log(data);
        console.log(resultPost);
        if (resultPost == 200) {
            $('#tUser').DataTable().ajax.reload();
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

    let userDetail = await Get("User", {
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
                                    <select  class="form-control" name="Id" id="EmployeeEdit"></select
                                </div>
                                <div class="form-group">
                                    <label  class="control-label">UserName</label>
                                    <input " class="form-control" name="UserName" value="${userDetail.userName}"/>
                                   
                                </div>
                                <div class="form-group">
                                    <label  class="control-label">Password</label>
                                    <input  class="form-control" name="Password" value="${userDetail.password}"/>
                                    
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
    
    const Employees = await GetAll("Employees");
    $("#EmployeeEdit").empty()
    $.each(Employees, function () {
        if (this.id == userDetail.manager_Id) {
            $('#EmployeeEdit').append(`<option value="${this.id}" selected="selected">${this.firstName} ${this.lastName}</option>`);
        }
        else {
            $("#EmployeeEdit").append($("<option />").val(this.id).text(`${this.firstName} ${this.lastName}`));
        }

    });
    $("#Edit").on("submit", async function (event) {
        var data = {};
        $('#Edit').serializeArray().map(function (x) { data[x.name] = x.value; });
        const resultPut = await Put("User", data);
        console.log(data);
        console.log(resultPut);
        if (resultPut == 200) {
            $('#tUser').DataTable().ajax.reload();
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
    
    let userDetail = await Get("User", {
        "id": id
    });
    let text = "";
    text = `
        <div class="row">
            <div class="col">
                Name
            </div>
            <div class="col">
                ${userDetail.employees.firstName} ${userDetail.employees.lastName}
            </div>
        </div>
        <div class="row">
            <div class="col">
                UserName
            </div>
            <div class="col">
               ${userDetail.userName}
            </div>
        </div>
        <div class="row">
            <div class="col">
                Password
            </div>
            <div class="col">
               ${userDetail.password}
            </div>
        </div>
        
    
    `;
    $("#ModalTitle").text("Details");
    $("#ModalBody").html(text);
};


$(document).ready(function () {

    $('#tUser').DataTable({

        dom: "<'row'<'col'l><'col'B><'col'f>>"
            + "<'row'<'col-sm-12'tr>>"
            + "<'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7'p>>"
        //dom: 'lBfrtip'
        ,
        buttons: [

            {
                extend: 'excelHtml5',
                name: 'excel',
                title: 'User',
                sheetName: 'User',
                text: 'download',
                className: 'btn-default',
                filename: 'DataUser',
                autoFilter: true,
                exportOptions: {
                    columns: [0, 1]
                }
            }
        ],
        "ajax": {
            type: 'GET',
            url: `/User/GetAll`,
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
            {
                "data": "",
                "render": function (data, type, row) {
                    return `${row.employees.firstName} ${row.employees.lastName} `;
                }
            },
            { "data": "userName" },
            { "data": "password" },
            {
                "data": "",
                "render": function (data, type, row) {
                    return `
                        <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#ModalData" onclick="Edit('${row.id}')">Edit</button>
                        <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#ModalData" onclick="Detail('${row.id}')">Detail</button>
                        <button type="button" class="btn btn-primary" onclick="confirmDelete('tUser','User',${row.id})">Delete</button>
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