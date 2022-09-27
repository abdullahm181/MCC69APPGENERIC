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
    $("#modalBodyEmployee").html(text);
};

function Edit(id) {
    //console.log("Test masuk create")
    var str = @Html.Raw(Json.Encode(ViewData["Text"]));
    let text = "";
    text = `
        <div class="addselection">
            <partial name="" model="@Model.DropdownListViewModel" />
            <div class="row">
                        <div class="col">
                            <form id="Edit">
                                <div asp-validation-summary="ModelOnly" class="text-danger"></div>
                                <input type="hidden" asp-for="Id" />
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
                                    <select asp-for="Job_Id" class="form-control" asp-items="ViewBag.Job_Id"></select>
                                    <span asp-validation-for="Job_Id" class="text-danger"></span>
                                </div>
                                <div class="form-group">
                                    <label asp-for="Manager_Id" class="control-label"></label>
                                    <select asp-for="Manager_Id" class="form-control" asp-items="ViewBag.Manager_Id"></select>
                                    <span asp-validation-for="Manager_Id" class="text-danger"></span>
                                </div>
                                <div class="form-group">
                                    <label asp-for="Department_Id" class="control-label"></label>
                                    <select asp-for="Department_Id" class="form-control" asp-items="ViewBag.Department_Id"></select>
                                    <span asp-validation-for="Department_Id" class="text-danger"></span>
                                </div>
                                <div class="form-group">
                                    <input type="submit" value="Save" class="btn btn-primary" />
                                </div>
                            </form>
                        </div>
                    </div>
        </div
        
    `;
    $("#ModalEmployeeTitle").text("Edit");
    $("#modalBodyEmployee").html(text);
    $.ajax({
        type: 'GET',
        url: `/Employees/Edit`,
        data: {
            id: id,

        },
    }).done(result => {
        $(".addselection").append(result);
    }).fail((error) => {
        console.log(error);
    });;
    
};
function Details(id) {
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
    $("#modalBodyEmployee").html(text);
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
    $("#modalBodyEmployee").html(text);
};