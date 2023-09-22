//Jquery funcion para cuando se carge la pagina/cuando este lista, se ejecute todo lo que esta dentro de .ready
$(document).ready(function () {
    loadData();
})

//Cargar datos mediante ajax
function loadData() {
    $.ajax({
        url: "/Home/GetAllEmployee", //A la funcion que va a llamar dentro del controlador
        type: "GET",//Tipo GET: Traer datos
        contentType: "application/json;charset=utf-8",//Tipo de contenidos, siempre esto creo :P
        dataType: "json",//Tipo de datos
        success: function (result) {//cuando se exitoso, se construya el html
            var html = '';
            $.each(result, function (key, item) {
                var ok = (item.Estado) ? "" : "background:#f56363; ";
                html += '<tr style="' + ok + '">';                
                html += '<th scope="row">' + item.IDEmpleados + '</th>';
                html += '<td>' + item.Apellidos + '</td>';
                html += '<td>' + item.Nombres + '</td>';
                html += '<td>' + item.Telefono + '</td>';
                html += '<td>' + item.Correo + '</td>';
                html += '<td>' + item.Pais + '</td>';
                html += '<td>' + item.Provincia + '</td>';
                html += '<td>' + item.Canton + '</td>';
                html += '<td>' + item.Direccion + '</td>';
                var Estado = (item.Estado) ? "Activo" : "Eliminado";
                html += '<td>' + Estado + '</td>';
                html += '<td><a href="#" class="btn btn-warning btn-sm" onclick="return GetByID(' + item.IDEmpleados + ')"><i class="bi bi-pencil"></i></a> <a href="#" class="btn btn-danger btn-sm btnDelete" onclick="return Delete(' + item.IDEmpleados + ')"><i class="bi bi-trash-fill"></i></a></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);//agrego lo que tiene la variable html, a lo que hay en la clase .tbody
        },
        error: function (errormessage) {//capturar errores
            alert(errormessage.responseText);//muestro un alert si hay errores
        }
    });
}

//Funcion obtener empleados apartir el IDEmpleado
function GetByID(IDEmpleado) {
    $.ajax({
        url: "/Home/GetEmplooyeByIDEmployee?IDEmployee=" + IDEmpleado,//Direccion de la funcion dentro del controlador a donde se va a ir los datos
        typr: "GET",//Tipo de metodo GET: Para OBTENER DATOS
        contentType: "application/json;charset=UTF-8",
        dataType: "json",//Tipo de dato
        success: function (result) {//Cuando se exitoso, carge los datos en las cajas de texto y abra el modal

            $('#IDEmpleado').val(result.IDEmpleados);
            $('#Apellidos').val(result.Apellidos);
            $('#Nombres').val(result.Nombres);
            $('#Telefono').val(result.Telefono);
            $('#Correo').val(result.Correo);
            $('#Pais').val(result.Pais);
            $('#Provincia').val(result.Provincia);
            $('#Canton').val(result.Canton);
            $('#Direccion').val(result.Direccion);

            $('#employeeModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            console.log(errormessage.responseText);
            alert(errormessage.responseText);
        }
    });
    return false;
}

//Agregar registros
function Add() {
    var ok = Validate();//Llamo funcion de validar
    if (ok == false) {
        Alert.error('Por favor, Completa los campos con *', 'Error', { displayDuration: 3000 });
        return false;
    }
    var employeeObj = { //creamos objeto de tipo Employee, tal cual esta en las entidades/Model y enviamos el nomde de la Entidad/Modelo y asignamos al ID del html mediante #IDEmpleado
        IDEmpleados: $('#IDEmpleado').val(),
        Apellidos: $('#Apellidos').val(),
        Nombres: $('#Nombres').val(),
        Telefono: $('#Telefono').val(),
        Correo: $('#Correo').val(),
        Pais: $('#Pais').val(),
        Provincia: $('#Provincia').val(),
        Canton: $('#Canton').val(),
        Direccion: $('#Direccion').val()
    };
    $.ajax({
        url: "/Home/InsertEmployee",//A la funcion que va a llamar dentro del controlador
        data: JSON.stringify(employeeObj),//Enviamos el objeto de tipo entidades/Model, pero lo convertimos de tipo JavaScript a JSON
        type: "POST",//Tipo de metodo POST: Insertar
        contentType: "application/json;charset=utf-8",
        dataType: "json",//Tipo de dato
        success: function (result) {//Cuando se exitoso, carge de nuevo los datos y oculte el modal
            loadData();
            clearTextBox();            
            Alert.success('Registro agregado', 'Éxito', { displayDuration: 3000 });
        },
        error: function (errormessage) {
            console.log(errormessage.responseText);
            alert(errormessage.responseText);
        }
    });
}

//Funcion actualizar
function Update() {
    var ok = Validate();//Llamo funcion de validar
    if (ok == false) {
        Alert.error('Por favor, Completa los campos con * ', 'Error', { displayDuration: 5000 });
        return false;
    }
    var employeeObj = { //creamos objeto de tipo Employee, tal cual esta en las entidades/Model y enviamos el nomde de la Entidad/Modelo y asignamos al ID del html mediante #IDEmpleado
        IDEmpleados: $('#IDEmpleado').val(),
        Apellidos: $('#Apellidos').val(),
        Nombres: $('#Nombres').val(),
        Telefono: $('#Telefono').val(),
        Correo: $('#Correo').val(),
        Pais: $('#Pais').val(),
        Provincia: $('#Provincia').val(),
        Canton: $('#Canton').val(),
        Direccion: $('#Direccion').val()
    };
    $.ajax({
        url: "/Home/UpdateEmployee",//A la funcion que va a llamar dentro del controlador
        data: JSON.stringify(employeeObj),//Enviamos el objeto de tipo entidades/Model, pero lo convertimos de tipo JavaScript a JSON
        type: "POST",//Tipo de metodo POST: INSERTAR/EDITAR
        contentType: "application/json;charset=utf-8",
        dataType: "json",//Tipo de dato
        success: function (result) {//Cuando se exitoso, carge de nuevo los datos y oculte el modal
            loadData();
            $('#employeeModal').modal('hide');
            clearTextBox();
        },
        error: function (errormessage) {
            console.log(errormessage.responseText);
            alert(errormessage.responseText);
        }
    });
}

//Funcion eliminar
function Delete(IDEmpleado) {
    var ans = confirm("¿Está seguro de eliminar este registro?");
    if (ans) {
        $.ajax({
            url: "/Home/DeleteEmployeeByIDEmployee?IDEmployee=" + IDEmpleado,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                loadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}  


//Validar usando Jquery
function Validate() {
    var isValid = true;
    if ($('#Apellidos').val().trim() == "") {
        isValid = false;
    }
    if ($('#Nombres').val().trim() == "") {
        isValid = false;
    }
    if ($('#Telefono').val().trim() == "") {
        isValid = false;
    }
    if ($('#Correo').val().trim() == "") {
        isValid = false;
    }
    if ($('#Pais').val().trim() == "") {
        isValid = false;
    }
    if ($('#Provincia').val().trim() == "") {
        isValid = false;
    }
    if ($('#Canton').val().trim() == "") {
        isValid = false;
    }
    if ($('#Direccion').val().trim() == "") {
        isValid = false;
    }
    return isValid;
}

//Limpiar controles
function clearTextBox() {
    $('#IDEmpleado').val("");
    $('#Apellidos').val("");
    $('#Nombres').val("");
    $('#Telefono').val("");
    $('#Correo').val("");
    $('#Pais').val("");
    $('#Provincia').val("");
    $('#Canton').val("");
    $('#Direccion').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#Apellidos').focus();
}