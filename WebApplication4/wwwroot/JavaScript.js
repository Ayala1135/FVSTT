//$("button").click(() => {
//    const userName = document.getElementById('name').value;
//    const password = document.getElementById('pass').value;
//    //let userName = $('#name')
//    //console.log(userName);
//    //let password = $('#pass').value
//    let url = "api/LogIn/GetUserByNameAndPassword/" + userName + "/" + password;
//    $.ajax({
//        type: "Get",
//        url: url,
//        success: function (result) {
//            $("#div1").html(result);
//        },
//    }).done(function (Response) {
//        console.log(Response);
//        $("#div1").html(result);
//    })

//        .fail(function (Response) {
//            console.log(Response)
//        });
//});

//$(document).ready(function () {

//    Console.log("sfdgf")
//    console.log("sdfghj")
//    debugger
//    $.ajax({
//        url: "https://localhost:44323/api/City/GetCities",
//        type: 'GET',
//        //dataType: 'json', // added data type
//        success: function (res)
//            //console.log(res)
//            alert(res)
//        }
//    });
//});
//פונקצייה בעת טעינת הדף מביאה את כל
var AllCity
$(document).ready(function () {
    $.ajax({
        type: "Get",//סוג השליחה
        url: "https://localhost:44323/api/City/GetCities",
        contentType: "application/json; charset=utf-8",
        async: false,
        cache: false
    }).done(function (Response) {
        const IdSelectCity = document.getElementById('IdSelectCity');
        AllCity = Response;
        for (var i = 0; i < Response.length; i++) {
            const OPTHION = document.createElement("option");
            OPTHION.innerText = Response[i].nameCity;
            IdSelectCity.appendChild(OPTHION);
        }
        var text = IdSelectCity.options[IdSelectCity.selectedIndex].text;
        alert(text)
    })
        .fail(function (Response) {
            console.log(Response)
        });

});

function funcToShowAllStreetOfThisCity() {
    const IdSelectCity = document.getElementById('IdSelectCity');
    debugger
    var text = IdSelectCity.options[IdSelectCity.selectedIndex].text;
    var num
    for (var i = 0; i < AllCity.length; i++) {
        if (AllCity[i].nameCity == text)
            num = AllCity[i].idCity
    }
    //const num=101
    if (text != "בחר עיר.......") {

        $.ajax({
            type: "Get",//סוג השליחה
            url: "https://localhost:44323/api/City/GetAllStreetsOfCityByIdCity/" + num,
            contentType: "application/json; charset=utf-8",
            async: false,
            cache: false
        }).done(function (Response) {
            debugger;
            if (Response == undefined || Response == null)
                alert("לעיר זו אין רחובות")
            //const IdSelectStreet = document.getElementById('IdSelectStreet');
            else {
                for (var i = 0; i < Response.length; i++) {
                    const IdSelectStreet = document.querySelector('#IdSelectStreet');
                    const OPTHION = document.createElement("option");
                    OPTHION.innerText = Response[i].nameStreet;
                    IdSelectStreet.appendChild(OPTHION);
                }
            }
        })
            .fail(function (Response) {
                console.log(Response)
            });
    }
}

function OnClickSave() {
    debugger;
    const NameStreetId = document.getElementById('NameStreetId').value;
    const NameCityId = document.getElementById('NameCityId').value;
    if (NameCityId != "" && NameStreetId == "") {
        $.ajax({
            type: "Get",//סוג השליחה
            url: "https://localhost:44323/api/City/AddCity/" + NameCityId,
            contentType: "application/json; charset=utf-8",
            async: false,
            cache: false
        }).done(function (Response) {
            debugger;
            if (Response.length > 0) {
                alert("העיר נוספה בהצלחה")
            }

            else
                alert("הוספת שם העיר נכשלה בעקבות שקיים עיר כזו כבר במאגר");
        })
            .fail(function (Response) {
                console.log(Response)
            });
    }
    else if (NameCityId == "" && NameStreetId != "") {
        $.ajax({
            type: "Get",//סוג השליחה
            url: "https://localhost:44323/api/Street/AddStreet/" + NameStreetId,
            contentType: "application/json; charset=utf-8",
            async: false,
            cache: false
        }).done(function (Response) {
            debugger;
            if (Response == true) {
                alert("הרחוב נוסף בהצלחה")
            }

            else
                alert("הוספת שם הרחוב נכשלה בעקבות שקיים רחוב כזה כבר במאגר");
        })
            .fail(function (Response) {
                console.log(Response)
            });
    }
    else if (NameCityId != "" && NameStreetId != "") {
        $.ajax({
            type: "Get",//סוג השליחה
            url: "https://localhost:44323/api/City/AddCity/" + NameCityId,
            contentType: "application/json; charset=utf-8",
            async: false,
            cache: false
        }).done(function (Response) {
            debugger;
            if (Response.length > 0) {
                alert("העיר נוספה בהצלחה")
                $.ajax({
                    type: "Get",//סוג השליחה
                    url: "https://localhost:44323/api/Street/AddStreet/" + NameStreetId,
                    contentType: "application/json; charset=utf-8",
                    async: false,
                    cache: false
                }).done(function (Response) {
                    debugger;
                    if (Response == true) {
                        alert("הרחוב נוסף בהצלחה")
                        $.ajax({
                            type: "Get",//סוג השליחה
                            url: "https://localhost:44323/api/Street/AddStreetToSpesificCity/" + NameStreetId + "/" + NameCityId,
                            contentType: "application/json; charset=utf-8",
                            async: false,
                            cache: false
                        }).done(function (Response) {
                            debugger;
                            if (Response == true) {
                                alert("הרחוב נוסף לעיר בהצלחה")

                            }

                            else
                                alert("הוספת שם הרחוב נכשלה בעקבות שקיים רחוב כזה כבר בעיר זו");
                        })
                            .fail(function (Response) {
                                console.log(Response)
                            });
                    }
                    else
                        alert("הוספת שם הרחוב נכשלה בעקבות שקיים רחוב כזה כבר במאגר");
                })
                    .fail(function (Response) {
                        console.log(Response)
                    });
            }

            else
                alert("הוספת שם העיר נכשלה בעקבות שקיים עיר כזו כבר במאגר");
        })
            .fail(function (Response) {
                console.log(Response)
            });
    }
}
function OnClickCan() {
    debugger;
    document.getElementById('NameStreetId').value = '';
    document.getElementById('NameCityId').value = '';
}