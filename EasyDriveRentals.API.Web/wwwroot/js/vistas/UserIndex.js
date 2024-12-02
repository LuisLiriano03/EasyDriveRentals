const modelBase = {
    id: 0,
    idNumber: "",
    fullName: "",
    genderId: 0,
    phoneNumber: "",
    email: "",
    passwordHash: "",
    rolId: 0,
    isActive: 1
}

let dataTable;

$(document).ready(function () {

    //fetch("/gender/GenderList")
    //    .then(response => {
    //        return response.ok ? response.json() : Promise.reject(response);
    //    })
    //    .then(responseJson => {
    //        if (responseJson.length > 0) {
    //            responseJson.forEach((item) => {
    //                $("#cboGender").append(
    //                    $("<option>").val(item.genderId).text(item.name)
    //                )
    //            })
    //        }
    //    })

    //fetch("/rol/GetRoles")
    //    .then(response => {
    //        return response.ok ? response.json() : Promise.reject(response);
    //    })
    //    .then(responseJson => {
    //        if (responseJson.length > 0) {
    //            responseJson.forEach((item) => {
    //                $("#cboRol").append(
    //                    $("<option>").val(item.rolId).text(item.name)
    //                )
    //            })
    //        }
    //    })

    

    if ($.fn.dataTable.isDataTable('#tbdata')) {
        $('#tbdata').DataTable().clear().destroy();
    }

    // Inicializa el DataTable
    dataTable = $('#tbdata').DataTable({
        responsive: true,
        deferRender: true,
        "ajax": {
            "url": 'user/GetUsers',
            "type": "GET",
            "datatype": "json",
            "dataSrc": function (json) {
                return json.value || json;
            }
        },
        "columns": [
            { "data": "id", "visible": false, "searchable": false },
            { "data": "idNumber" },
            { "data": "fullName" },
            { "data": "genderDescription" },
            { "data": "phoneNumber" },
            { "data": "email" },
            { "data": "rolDescription" },
            {
                "data": "isActive", render: function (data) {
                    return data == 1
                        ? '<span class="badge badge-info">Activo</span>'
                        : '<span class="badge badge-danger">No Activo</span>';
                }
            },
            {
                "defaultContent": `
                    <button class="btn btn-primary btn-editar btn-sm mr-2">
                        <i class="fas fa-pencil-alt"></i>
                    </button>
                    <button class="btn btn-danger btn-eliminar btn-sm">
                        <i class="fas fa-trash-alt"></i>
                    </button>
                `,
                "orderable": false,
                "searchable": false,
                "width": "80px"
            }
        ],
        order: [[0, "asc"]],
        dom: "Bfrtip",
        buttons: [
            {
                text: 'Exportar Excel',
                extend: 'excelHtml5',
                title: '',
                filename: 'Reporte Usuarios',
                exportOptions: {
                    columns: [1,2,3,4,5,6,7]
                }
            },
            'pageLength'
        ],
        language: {
            url: "https://cdn.datatables.net/plug-ins/1.11.5/i18n/es-ES.json"
        },
    });
});


//function mostrarModal(model = modelBase) {
//    $("#txtId").val(model.id)
//    $("#txtIdNumber").val(model.idNumber)
//    $("#txtFullName").val(model.fullName)
//    $("#cboGender").val(model.genderId == 0 ? $("#cboGender option:first").val() : model.genderId)
//    $("#txtPhoneNumber").val(model.phoneNumber)
//    $("#txtEmail").val(model.email)
//    $("#txtPassword").val(model.passwordHash)
//    $("#cboRol").val(model.rolId == 0 ? $("#cboRol option:first").val() : model.rolId)
//    $("#cboEstado").val(model.isActive)

//    $("#modalData").modal("show")
//}

function mostrarModal(model = modelBase) {
    $("#txtId").val(model.id);
    $("#txtIdNumber").val(model.idNumber);
    $("#txtFullName").val(model.fullName);
    $("#cboGender").val(model.genderId || $("#cboGender option:first").val());
    $("#txtPhoneNumber").val(model.phoneNumber);
    $("#txtEmail").val(model.email);
    $("#txtPassword").val(model.passwordHash);
    $("#cboRol").val(model.rolId || $("#cboRol option:first").val());
    $("#cboEstado").val(model.isActive);

    $("#modalData").modal("show");
}


$("#btnNuevo").click(function () {
    mostrarModal()
})

//$("#btnGuardar").click(function () {
//    const inputs = $("input.input-validar").serializeArray();
//    const inputsSinValor = inputs.filter((item) => item.value.trim() === "");

//    if (inputsSinValor.length > 0) {
//        const mensaje = `Debe completar el campo: "${inputsSinValor[0].name}"`;
//        toastr.warning("", mensaje);
//        $(`input[name="${inputsSinValor[0].name}"]`).focus();
//        return;
//    }

//    // Crear el modelo a enviar
//    const model = {
//        idNumber: $("#txtIdNumber").val(),
//        fullName: $("#txtFullName").val(),
//        genderId: parseInt($("#cboGender").val()) || 0, // Asegura un valor numérico
//        phoneNumber: $("#txtPhoneNumber").val(),
//        email: $("#txtEmail").val(),
//        passwordHash: $("#txtPassword").val(),
//        rolId: parseInt($("#cboRol").val()) || 0 // Asegura un valor numérico
//    };

//    $("#modalData").find("div.modal-content").LoadingOverlay("show");

//    fetch("/user/Register", {
//        method: "POST",
//        headers: {
//            "Content-Type": "application/json" // Aseguramos que sea JSON
//        },
//        body: JSON.stringify(model) // Convertir a JSON
//    })
//        .then(response => {
//            $("#modalData").find("div.modal-content").LoadingOverlay("hide");
//            return response.ok ? response.json() : Promise.reject(response);
//        })
//        .then(responseJson => {
//            if (responseJson.status) {
//                dataTable.row.add(responseJson.value).draw(false);
//                $("#modalData").modal("hide");
//                swal("Listo!", "El usuario fue creado", "success");
//            } else {
//                swal("Lo sentimos!", responseJson.message, "error");
//            }
//        })
//        .catch(error => {
//            console.error("Error en la solicitud:", error);
//            swal("Error!", "Ocurrió un error al guardar el usuario.", "error");
//        });
//});

$("#btnGuardar").click(function () {
    const genderId = $("#cboGender").val();  // Obtener el valor de genero
    const rolId = $("#cboRol").val();        // Obtener el valor de rol

    //console.log('genderId:', genderId);      // Verifica el valor
    //console.log('rolId:', rolId);            // Verifica el valor

    const inputs = $("input.input-validar").serializeArray();
    const inputsSinValor = inputs.filter((item) => item.value.trim() === "");

    if (inputsSinValor.length > 0) {
        const mensaje = `Debe completar el campo: "${inputsSinValor[0].name}"`;
        toastr.warning("", mensaje);
        $(`input[name="${inputsSinValor[0].name}"]`).focus();
        return;
    }

    // Crear el modelo a enviar
    const model = {
        idNumber: $("#txtIdNumber").val(),
        fullName: $("#txtFullName").val(),
        genderId: parseInt(genderId) || 0, // Asegura que se envíe un valor numérico
        phoneNumber: $("#txtPhoneNumber").val(),
        email: $("#txtEmail").val(),
        passwordHash: $("#txtPassword").val(),
        rolId: parseInt(rolId) || 0 // Asegura que se envíe un valor numérico
    };

    console.log("Modelo a enviar:", model); // Verifica el modelo que se enviará

    $("#modalData").find("div.modal-content").LoadingOverlay("show");

    fetch("/user/Register", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(model)
    })
        .then(response => {
            $("#modalData").find("div.modal-content").LoadingOverlay("hide");
            return response.ok ? response.json() : Promise.reject(response);
        })
        .then(responseJson => {
            if (responseJson.status) {
                dataTable.row.add(responseJson.value).draw(false);
                $("#modalData").modal("hide");
                swal("Listo.", "El usuario fue creado.", "success");
            } else {
                swal("Lo sentimos!", responseJson.message, "error");
            }
        })
        .catch(error => {
            console.error("Error en la solicitud:", error);
            swal("Error.", "Ocurrió un error al guardar el usuario.", "error");
        });
});


//$("#btnGuardar").click(function () {

//    const inputs = $("input.input-validar").serializeArray();
//    const inputsSinValor = inputs.filter((item) => item.value.trim() == "")

//    if (inputsSinValor.length > 0) {
//        const mensaje = `Debe completar el campo: "${inputsSinValor[0].name}"`;
//        toastr.warning("", mensaje)
//        $(`input[name="${inputsSinValor[0].name}"]`).focus()
//        return;
//    }

//    const model = structuredClone(modelBase);
//    model["id"] = parseInt($("#txtId").val())
//    model["idNumber"] = $("#txtIdNumber").val()
//    model["fullName"] = $("#txtFullName").val()
//    model["genderId"] = $("#cboGender").val()
//    model["phoneNumber"] = $("#txtPhoneNumber").val()
//    model["email"] = $("#txtEmail").val()
//    model["passwordHash"] = $("#txtPassword").val()
//    model["rolId"] = $("#cboRol").val()
//    model["isActive"] = $("#cboEstado").val()

//    const formData = new FormData();

//    formData.append("model", JSON.stringify(model))

//    $("#modalData").find("div.modal-content").LoadingOverlay("show");


//    if (model.id == 0) {
//        fetch("/user/Register", {
//            method: "POST",
//            body: formData
//        })
//            .then(response => {
//                $("#modelData").find("div.modal-content").LoadingOverlay("hide");
//                return response.ok ? response.json() : Promise.reject(response);
//            })
//            .then(responseJson => {
//                if (responseJson.status) {
//                    dataTable.row.add(responseJson.value).draw(false)
//                    $("#modalData").modal("hide")
//                    swal("Listo!", "El usuario fue creado", "success")
//                } else {
//                    swal("Los sentimos!", responseJson.message, "success")
//                }
//            })
//    }
//})

//$("#btnGuardar").click(function () {
//    // Validación de inputs
//    const inputs = $("input.input-validar").serializeArray();
//    const inputsSinValor = inputs.filter((item) => item.value.trim() === "");

//    if (inputsSinValor.length > 0) {
//        const mensaje = `Debe completar el campo: "${inputsSinValor[0].name}"`;
//        toastr.warning("", mensaje);
//        $(`input[name="${inputsSinValor[0].name}"]`).focus();
//        return;
//    }

//    // Construcción del modelo
//    const model = structuredClone(modelBase);
//        model["id"] = parseInt($("#txtId").val())
//        model["idNumber"] = $("#txtIdNumber").val()
//        model["fullName"] = $("#txtFullName").val()
//        model["genderId"] = $("#cboGender").val()
//        model["phoneNumber"] = $("#txtPhoneNumber").val()
//        model["email"] = $("#txtEmail").val()
//        model["passwordHash"] = $("#txtPassword").val()
//        model["rolId"] = $("#cboRol").val()
//        model["isActive"] = $("#cboEstado").val()

//    $("#modalData").find("div.modal-content").LoadingOverlay("show");

//    // Llamada al servidor
//    fetch("/user/Register", {
//        method: "POST",
//        headers: {
//            "Content-Type": "application/json"
//        },
//        body: JSON.stringify(model) // Enviar el modelo como JSON
//    })
//        .then(response => {
//            $("#modalData").find("div.modal-content").LoadingOverlay("hide");

//            if (response.ok) {
//                return response.json(); // Si la respuesta es correcta, convertir a JSON
//            } else {
//                return response.json().then(err => Promise.reject(err)); // Capturar errores del servidor
//            }
//        })
//        .then(responseJson => {
//            if (responseJson.status) {
//                // Si todo está correcto, agregar el usuario al DataTable
//                dataTable.row.add(responseJson.value).draw(false);
//                $("#modalData").modal("hide"); // Cerrar modal
//                swal("Listo!", "El usuario fue creado", "success"); // Mostrar alerta de éxito
//            } else {
//                swal("Lo sentimos!", responseJson.message, "error"); // Mostrar alerta de error con el mensaje del backend
//            }
//        })
//        .catch(err => {
//            console.error("Error al registrar:", err); // Log del error para depuración
//            swal("Error!", "No se pudo procesar la solicitud.", "error"); // Alerta genérica de error
//        });
//});


