﻿


function Create() {
    //console.log("Test masuk create")

    let text = "";
    text = `
        <div class="row">
            <div class="col">
                <form >
                    <div asp-validation-summary="ModelOnly" class="text-danger"></div>
                    <div class="form-group">
                        <label asp-for="FirstName" class="control-label"></label>
                        <input asp-for="FirstName" class="form-control" />
                        <span asp-validation-for="FirstName" class="text-danger"></span>
                    </div>
                    <div class="form-group">
                        <label asp-for="LastName" class="control-label"></label>
                        <input asp-for="LastName" class="form-control" />
                        <span asp-validation-for="LastName" class="text-danger"></span>
                    </div>
                    <div class="form-group">
                        <label asp-for="Email" class="control-label"></label>
                        <input asp-for="Email" class="form-control" />
                        <span asp-validation-for="Email" class="text-danger"></span>
                    </div>
                    <div class="form-group">
                        <label asp-for="PhoneNumber" class="control-label"></label>
                        <input asp-for="PhoneNumber" class="form-control" />
                        <span asp-validation-for="PhoneNumber" class="text-danger"></span>
                    </div>
                    <div class="form-group">
                        <label asp-for="HireDate" class="control-label"></label>
                        <input asp-for="HireDate" class="form-control" />
                        <span asp-validation-for="HireDate" class="text-danger"></span>
                    </div>
                    <div class="form-group">
                        <label asp-for="Salary" class="control-label"></label>
                        <input asp-for="Salary" class="form-control" />
                        <span asp-validation-for="Salary" class="text-danger"></span>
                    </div>
                    <div class="form-group">
                        <label asp-for="Job_Id" class="control-label"></label>
                        <select asp-for="Job_Id" class ="form-control" asp-items="ViewBag.Job_Id"></select>
                    </div>
                    <div class="form-group">
                        <label asp-for="Manager_Id" class="control-label"></label>
                        <select asp-for="Manager_Id" class ="form-control" asp-items="ViewBag.Manager_Id"></select>
                    </div>
                    <div class="form-group">
                        <label asp-for="Department_Id" class="control-label"></label>
                        <select asp-for="Department_Id" class ="form-control" asp-items="ViewBag.Department_Id"></select>
                    </div>
                    <div class="form-group">
                        <input type="submit" value="Create" class="btn btn-primary" />
                    </div>
                </form>
            </div>
        </div>
    `;
    $("#ModalEmployeeTitle").text("Create");
    $("#ModalBody").html(text);
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
                            <form id="Edit">
                                <div asp-validation-summary="ModelOnly" class="text-danger"></div>
                                <input type="hidden" asp-for="Id" />
                                <div class="form-group">
                                    <label asp-for="FirstName" class="control-label"></label>
                                    <input asp-for="FirstName" class="form-control" name="FirstName" value="${employeeDetail.firstName}" />
                                    <span asp-validation-for="FirstName" class="text-danger"></span>
                                </div>
                                <div class="form-group">
                                    <label asp-for="LastName" class="control-label"></label>
                                    <input asp-for="LastName" class="form-control" name="LastName" value="${employeeDetail.lastName}"/>
                                    <span asp-validation-for="LastName" class="text-danger"></span>
                                </div>
                                <div class="form-group">
                                    <label asp-for="Email" class="control-label"></label>
                                    <input asp-for="Email" class="form-control" name="Email" value="${employeeDetail.email}"/>
                                    <span asp-validation-for="Email" class="text-danger"></span>
                                </div>
                                <div class="form-group">
                                    <label asp-for="PhoneNumber" class="control-label"></label>
                                    <input asp-for="PhoneNumber" class="form-control" name="PhoneNumber" value="${employeeDetail.phoneNumber}"/>
                                    <span asp-validation-for="PhoneNumber" class="text-danger"></span>
                                </div>
                                <div class="form-group">
                                    <label asp-for="HireDate" class="control-label"></label>
                                    <input asp-for="HireDate" class="form-control" name="HireDate" value="${employeeDetail.hireDate}"/>
                                    <span asp-validation-for="HireDate" class="text-danger"></span>
                                </div>
                                <div class="form-group">
                                    <label asp-for="Salary" class="control-label"></label>
                                    <input asp-for="Salary" class="form-control" name="Salary" value="${employeeDetail.salary}"/>
                                    <span asp-validation-for="Salary" class="text-danger"></span>
                                </div>
                                <div class="form-group">
                                    <label asp-for="Job_Id" class="control-label"></label>
                                    
                                    <select asp-for="Job_Id" class="form-control" asp-items="ViewBag.Job_Id" name="Job_Id" id="JobEdit"></select>
                                    <span asp-validation-for="Job_Id" class="text-danger"></span>
                                </div>
                                <div class="form-group">
                                    <label asp-for="Manager_Id" class="control-label"></label>
                                    <select asp-for="Manager_Id" class="form-control" asp-items="ViewBag.Manager_Id" name="Manager_Id" id="EmployeesEdit"></select>
                                    <span asp-validation-for="Manager_Id" class="text-danger"></span>
                                </div>
                                <div class="form-group">
                                    <label asp-for="Department_Id" class="control-label"></label>
                                    <select asp-for="Department_Id" class="form-control" asp-items="ViewBag.Department_Id" name="Department_Id" id="DepartmentsEdit"></select>
                                    <span asp-validation-for="Department_Id" class="text-danger"></span>
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
    var data = {};
    $('#Edit').serializeArray().map(function (x) { data[x.name] = x.value; });
    console.log(data);
    
};
function Detail(id) {
    //console.log("Test masuk create")

    let text = "";
    text = `
        <dl class="row">
            <dt class = "col-sm-2">
                @Html.DisplayNameFor(model => model.FirstName)
            </dt>
            <dd class = "col-sm-10">
                @Html.DisplayFor(model => model.FirstName)
            </dd>
            <dt class = "col-sm-2">
                @Html.DisplayNameFor(model => model.LastName)
            </dt>
            <dd class = "col-sm-10">
                @Html.DisplayFor(model => model.LastName)
            </dd>
            <dt class = "col-sm-2">
                @Html.DisplayNameFor(model => model.Email)
            </dt>
            <dd class = "col-sm-10">
                @Html.DisplayFor(model => model.Email)
            </dd>
            <dt class = "col-sm-2">
                @Html.DisplayNameFor(model => model.PhoneNumber)
            </dt>
            <dd class = "col-sm-10">
                @Html.DisplayFor(model => model.PhoneNumber)
            </dd>
            <dt class = "col-sm-2">
                @Html.DisplayNameFor(model => model.HireDate)
            </dt>
            <dd class = "col-sm-10">
                @Html.DisplayFor(model => model.HireDate)
            </dd>
            <dt class = "col-sm-2">
                @Html.DisplayNameFor(model => model.Salary)
            </dt>
            <dd class = "col-sm-10">
                @Html.DisplayFor(model => model.Salary)
            </dd>
            <dt class = "col-sm-2">
                @Html.DisplayNameFor(model => model.Jobs)
            </dt>
            <dd class = "col-sm-10">
                @Html.DisplayFor(model => model.Jobs.Id)
            </dd>

            <dt class = "col-sm-2">
                @Html.DisplayNameFor(model => model.Departments)
            </dt>
            <dd class = "col-sm-10">
                @Html.DisplayFor(model => model.Departments.Id)
            </dd>
        </dl>
    `;
    $("#ModalEmployeeTitle").text("Details");
    $("#ModalBody").html(text);
};

function Delete(id) {
    //console.log(id);

    let text = "";
    text = `
        <div class="row">
            <div class="col">
                <form asp-action="Create">
                    <div asp-validation-summary="ModelOnly" class="text-danger"></div>
                    <div class="form-group">
                        <label asp-for="FirstName" class="control-label"></label>
                        <input asp-for="FirstName" class="form-control" />
                        <span asp-validation-for="FirstName" class="text-danger"></span>
                    </div>
                    <div class="form-group">
                        <label asp-for="LastName" class="control-label"></label>
                        <input asp-for="LastName" class="form-control" />
                        <span asp-validation-for="LastName" class="text-danger"></span>
                    </div>
                    <div class="form-group">
                        <label asp-for="Email" class="control-label"></label>
                        <input asp-for="Email" class="form-control" />
                        <span asp-validation-for="Email" class="text-danger"></span>
                    </div>
                    <div class="form-group">
                        <label asp-for="PhoneNumber" class="control-label"></label>
                        <input asp-for="PhoneNumber" class="form-control" />
                        <span asp-validation-for="PhoneNumber" class="text-danger"></span>
                    </div>
                    <div class="form-group">
                        <label asp-for="HireDate" class="control-label"></label>
                        <input asp-for="HireDate" class="form-control" />
                        <span asp-validation-for="HireDate" class="text-danger"></span>
                    </div>
                    <div class="form-group">
                        <label asp-for="Salary" class="control-label"></label>
                        <input asp-for="Salary" class="form-control" />
                        <span asp-validation-for="Salary" class="text-danger"></span>
                    </div>
                    <div class="form-group">
                        <label asp-for="Job_Id" class="control-label"></label>
                        <select asp-for="Job_Id" class ="form-control" asp-items="ViewBag.Job_Id"></select>
                    </div>
                    <div class="form-group">
                        <label asp-for="Manager_Id" class="control-label"></label>
                        <select asp-for="Manager_Id" class ="form-control" asp-items="ViewBag.Manager_Id"></select>
                    </div>
                    <div class="form-group">
                        <label asp-for="Department_Id" class="control-label"></label>
                        <select asp-for="Department_Id" class ="form-control" asp-items="ViewBag.Department_Id"></select>
                    </div>
                    <div class="form-group">
                        <input type="submit" value="Create" class="btn btn-primary" />
                    </div>
                </form>
            </div>
        </div>
    `;
    $("#ModalEmployeeTitle").text("Delete");
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
                        <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#ModalData" onclick="Create('${row.id}')">Delete</button>
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
    })()
});