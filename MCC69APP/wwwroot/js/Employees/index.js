


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
                                    <label class="control-label">FirstName</label>
                                    <input class="form-control" name="FirstName" />
                                   
                                </div>
                                <div class="form-group">
                                    <label class="control-label">LastName</label>
                                    <input class="form-control" name="LastName"/>
                                   
                                </div>
                                <div class="form-group">
                                    <label class="control-label">Email</label>
                                    <input class="form-control" name="Email"/>
                                   
                                </div>
                                <div class="form-group">
                                    <label  class="control-label">PhoneNumber</label>
                                    <input  class="form-control" name="PhoneNumber" />
                                    
                                </div>
                                <div class="form-group">
                                    <label  class="control-label">HireDate</label>
                                    <input  class="form-control" name="HireDate" />
                                    
                                </div>
                                <div class="form-group">
                                    <label class="control-label">Salary</label>
                                    <input  class="form-control" name="Salary" />
                                   
                                </div>
                                <div class="form-group">
                                    <label  class="control-label">Job_Id</label>
                                    <select  class="form-control" name="Job_Id" id="JobCreate"></select
                                </div>
                                <div class="form-group">
                                    <label  class="control-label">Manager_Id</label>
                                    <select  class="form-control"  name="Manager_Id" id="EmployeesCreate"></select>
                                    
                                </div>
                                <div class="form-group">
                                    <label  class="control-label">Department_Id</label>
                                    <select  class="form-control"  name="Department_Id" id="DepartmentsCreate"></select>
                                    
                                </div>
                                <div class="form-group">
                                    <input type="submit" value="Save" class="btn btn-primary" />
                                </div>
                            </form>
                        </div>
                    </div>
        </div
    `;
    $("#ModalEmployeeTitle").text("Create");
    $("#ModalBody").html(text);

    const Jobs = await GetAll("Jobs");
    $("#JobCreate").empty()
    $.each(Jobs, function () {
        $("#JobCreate").append($("<option />").val(this.id).text(this.jobTitle));

    });
    const Employees = await GetAll("Employees");
    $("#EmployeesCreate").empty()
    $.each(Employees, function () {
        $("#EmployeesCreate").append($("<option />").val(this.id).text(`${this.firstName} ${this.lastName}`));

    });
    const Departments = await GetAll("Departments");
    $("#DepartmentsCreate").empty()
    $.each(Departments, function () {
        $("#DepartmentsCreate").append($("<option />").val(this.id).text(this.name));

    });
    $("#Create").on("submit", async function (event) {
        var data = {};
        data["Id"] = 0;
        $('#Create').serializeArray().map(function (x) { data[x.name] = x.value; });
        const resultPost = await Post("Employees", data);
        console.log(data);
        console.log(resultPost);
        if (resultPost == 200) {
            $('#tEmployees').DataTable().ajax.reload();
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

    let employeeDetail = await Get("Employees", {
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
                                    <label  class="control-label">FirstName</label>
                                    <input class="form-control" name="FirstName" value="${employeeDetail.firstName}" />
                                    
                                </div>
                                <div class="form-group">
                                    <label  class="control-label">LastName</label>
                                    <input " class="form-control" name="LastName" value="${employeeDetail.lastName}"/>
                                   
                                </div>
                                <div class="form-group">
                                    <label  class="control-label">Email</label>
                                    <input  class="form-control" name="Email" value="${employeeDetail.email}"/>
                                    
                                </div>
                                <div class="form-group">
                                    <label  class="control-label">PhoneNumber</label>
                                    <input  class="form-control" name="PhoneNumber" value="${employeeDetail.phoneNumber}"/>
                                    
                                </div>
                                <div class="form-group">
                                    <label  class="control-label">HireDate</label>
                                    <input class="form-control" name="HireDate" value="${employeeDetail.hireDate}"/>
                                    
                                </div>
                                <div class="form-group">
                                    <label  class="control-label">Salary</label>
                                    <input class="form-control" name="Salary" value="${employeeDetail.salary}"/>
                                    
                                </div>
                                <div class="form-group">
                                    <label  class="control-label">Job_Id</label>
                                    
                                    <select class="form-control" name="Job_Id" id="JobEdit"></select>
                                    
                                </div>
                                <div class="form-group">
                                    <label  class="control-label">Manager_Id</label>
                                    <select  lass="form-control"  name="Manager_Id" id="EmployeesEdit"></select>
                                    
                                </div>
                                <div class="form-group">
                                    <label class="control-label">Department_Id</label>
                                    <select class="form-control"  name="Department_Id" id="DepartmentsEdit"></select>
                                    
                                </div>
                                <div class="form-group">
                                    <input type="submit" value="Save" class="btn btn-primary" />
                                </div>
                            </form>
                        </div>
                    </div>
        </div
        
    `

    $("#ModalEmployeeTitle").text("Edit");
    $("#ModalBody").html(text);
    const Jobs = await GetAll("Jobs");
    $("#JobEdit").empty()
    $.each(Jobs, function () {
        if (this.id == employeeDetail.job_Id) {
            $('#JobEdit').append(`<option value="${this.id}" selected="selected">${this.jobTitle}</option>`);
        }
        else {
            $("#JobEdit").append($("<option />").val(this.id).text(this.jobTitle));
        }

    });
    const Employees = await GetAll("Employees");
    $("#EmployeesEdit").empty()
    $.each(Employees, function () {
        if (this.id == employeeDetail.manager_Id) {
            $('#EmployeesEdit').append(`<option value="${this.id}" selected="selected">${this.firstName} ${this.lastName}</option>`);
        }
        else {
            $("#EmployeesEdit").append($("<option />").val(this.id).text(`${this.firstName} ${this.lastName}`));
        }

    });
    const Departments = await GetAll("Departments");
    $("#DepartmentsEdit").empty()
    $.each(Departments, function () {
        if (this.id == employeeDetail.department_Id) {
            $('#DepartmentsEdit').append(`<option value="${this.id}" selected="selected">${this.name}</option>`);
        }
        else {
            $("#DepartmentsEdit").append($("<option />").val(this.id).text(this.name));
        }

    });
    $("#Edit").on("submit", async function (event) {
        var data = {};
        data["Id"] = employeeDetail.id;
        $('#Edit').serializeArray().map(function (x) { data[x.name] = x.value; });
        const resultPut = await Put("Employees", data);
        console.log(data);
        console.log(resultPut);
        if (resultPut == 200) {
            $('#tEmployees').DataTable().ajax.reload();
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
    
    let employeeDetail = await Get("Employees", {
        "id": id
    });
    let text = "";
    text = `
        <div class="row">
            <div class="col">
                FirstName
            </div>
            <div class="col">
                ${employeeDetail.firstName}
            </div>
        </div>
        <div class="row">
            <div class="col">
                LastName
            </div>
            <div class="col">
               ${employeeDetail.lastName}
            </div>
        </div>
        <div class="row">
            <div class="col">
                Email
            </div>
            <div class="col">
               ${employeeDetail.email}
            </div>
        </div>
        <div class="row">
            <div class="col">
                PhoneNumber
            </div>
            <div class="col">
              ${employeeDetail.phoneNumber}
            </div>
        </div>
       <div class="row">
            <div class="col">
                HireDate
            </div>
            <div class="col">
              ${employeeDetail.hireDate}
            </div>
        </div>
        <div class="row">
            <div class="col">
                Salary
            </div>
            <div class="col">
              ${employeeDetail.salary}
            </div>
        </div>
        <div class="row">
            <div class="col">
                Jobs
            </div>
            <div class="col">
              ${employeeDetail.jobs.jobTitle}
            </div>
        </div>
        <div class="row">
            <div class="col">
                Departments
            </div>
            <div class="col">
                ${employeeDetail.departments.name}
            </div>
        </div>
        <div class="row">
            <div class="col">
                Manager_Id
            </div>
            <div class="col">
                ${employeeDetail.manager_Id}
            </div>
        </div>
    
    `;
    $("#ModalEmployeeTitle").text("Details");
    $("#ModalBody").html(text);
};


$(document).ready(function () {
    $('.CreateBtn').click(function () {
        var url = '/Employees/Create';
        $('#Create').load(url);
    });
    $('#tEmployees').DataTable({

        dom: "<'row'<'col'l><'col'B><'col'f>>"
            + "<'row'<'col-sm-12'tr>>"
            + "<'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7'p>>"
        //dom: 'lBfrtip'
        ,
        buttons: [

            {
                extend: 'excelHtml5',
                name: 'excel',
                title: 'Employees',
                sheetName: 'Employees',
                text: 'download',
                className: 'btn-default',
                filename: 'DataEmployees',
                autoFilter: true,
                exportOptions: {
                    columns: [0, 1]
                }
            }
        ],
        "ajax": {
            type: 'GET',
            url: `/Employees/GetAll`,
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
                    return `${row.firstName} ${row.lastName} `;
                }
            },
            { "data": "email" },
            { "data": "phoneNumber" },
            { "data": "hireDate" },
            { "data": "salary" },
            {
                "data": null,
                "render": function (data, type, row) {
                    return row.jobs.jobTitle;
                }
            },
            {
                "data": null,
                "render": function (data, type, row) {
                   
                    if (row.manager == null)
                        return "-";
                    else
                        return `${row.manager.firstName} ${row.manager.lastName}`;
                } },
            {
                "data": null,
                "render": function (data, type, row) {
                    return row.departments.name;
                }
            },
            {
                "data": "",
                "render": function (data, type, row) {
                    return `
                        <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#ModalData" onclick="Edit('${row.id}')">Edit</button>
                        <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#ModalData" onclick="Detail('${row.id}')">Detail</button>
                        <button type="button" class="btn btn-primary" onclick="confirmDelete('tEmployees','Employees',${row.id})">Delete</button>
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