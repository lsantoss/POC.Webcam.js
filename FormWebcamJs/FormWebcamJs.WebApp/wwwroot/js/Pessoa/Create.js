// Ao carregar a página configura a webcam
window.onload = function () {
    Webcam.set({
        width: 140,
        height: 110,
        image_format: 'png'
    });
    Webcam.attach('#divWebcam');
};

//Preenche a div com outras divs para o uso da webcam
function mostrarWebcam() {
    let divCameraPrincipal = document.createElement("div");
    divCameraPrincipal.setAttribute("class", "col-md-6");

    let divCameraPainelDefault = document.createElement("div");
    divCameraPainelDefault.setAttribute("class", "panel panel-default");

    let divCameraPainelHeading = document.createElement("div");
    divCameraPainelHeading.setAttribute("class", "panel-heading");
    divCameraPainelHeading.innerText = "Câmera";

    let divCameraPainelBody = document.createElement("div");
    divCameraPainelBody.setAttribute("class", "panel-body");

    let divCameraWebcam = document.createElement("div");
    divCameraWebcam.setAttribute("id", "divWebcam");
    divCameraWebcam.setAttribute("class", "center-block");

    let divCameraInputButtonTirarFoto = document.createElement("input");
    divCameraInputButtonTirarFoto.setAttribute("type", "button");
    divCameraInputButtonTirarFoto.setAttribute("class", "btn btn-primary");
    divCameraInputButtonTirarFoto.setAttribute("value", "Tirar foto");
    divCameraInputButtonTirarFoto.setAttribute("onClick", "tirarFoto()");

    divCameraPrincipal.appendChild(divCameraPainelDefault);
    divCameraPainelDefault.appendChild(divCameraPainelHeading);
    divCameraPainelDefault.appendChild(divCameraPainelBody);
    divCameraPainelBody.appendChild(divCameraWebcam);
    divCameraPainelBody.appendChild(document.createElement("br"));
    divCameraPainelBody.appendChild(divCameraInputButtonTirarFoto);

    let divResultadoPrincipal = document.createElement("div");
    divResultadoPrincipal.setAttribute("class", "col-md-6");

    let divResultadoPainelDefault = document.createElement("div");
    divResultadoPainelDefault.setAttribute("class", "panel panel-default");

    let divResultadoPainelHeading = document.createElement("div");
    divResultadoPainelHeading.setAttribute("class", "panel-heading");
    divResultadoPainelHeading.innerText = "Arte final";

    let divResultadoPainelBody = document.createElement("div");
    divResultadoPainelBody.setAttribute("class", "panel-body");

    let divResultadoImagem = document.createElement("div");
    divResultadoImagem.setAttribute("id", "resultadoImagem");
    divResultadoImagem.style.cssText = "height:160px;";

    divResultadoPrincipal.appendChild(divResultadoPainelDefault);
    divResultadoPainelDefault.appendChild(divResultadoPainelHeading);
    divResultadoPainelDefault.appendChild(divResultadoPainelBody);
    divResultadoPainelBody.appendChild(divResultadoImagem);

    document.getElementById('divEscolha').innerHTML = "";
    document.getElementById('divEscolha').appendChild(divCameraPrincipal);
    document.getElementById('divEscolha').appendChild(divResultadoPrincipal);
    document.getElementById('imagemBase64StringField').value = "";

    Webcam.set({
        width: 140,
        height: 110,
        image_format: 'png'
    });
    Webcam.attach('#divWebcam');
}

// Preenche a div com um input type file, para escolha de uma imagem local
function mostrarInputFile() {
    Webcam.reset();

    let divPainelDefault = document.createElement("div");
    divPainelDefault.setAttribute("class", "panel panel-default");

    let divColMd12 = document.createElement("div");
    divColMd12.setAttribute("class", "col-md-12");

    let divPainelHeading = document.createElement("div");
    divPainelHeading.setAttribute("class", "panel-heading");
    divPainelHeading.innerText = "Adicionar imagem local";

    let divPainelBody = document.createElement("div");
    divPainelBody.setAttribute("class", "panel-body");

    let p = document.createElement("p");
    p.innerText = "Recomendamos que escolha uma imagem de tamanho 140x180 e de formato .png";

    let inputFile = document.createElement("input");
    inputFile.setAttribute("type", "file");
    inputFile.setAttribute("class", "btn btn-primary");
    inputFile.setAttribute("accept", "image/*");
    inputFile.setAttribute("onchange", "obterArquivoInputFile(this)");

    divPainelDefault.appendChild(divColMd12);
    divColMd12.appendChild(divPainelHeading);
    divColMd12.appendChild(divPainelBody);
    divPainelBody.appendChild(p);
    divPainelBody.appendChild(inputFile);

    document.getElementById('divEscolha').innerHTML = "";
    document.getElementById('divEscolha').appendChild(divPainelDefault);
    document.getElementById('imagemBase64StringField').value = "";
}

// Captura imagem ao clicar no botão "Tirar foto"
// Mostra resultadoImagem na página
// #imagemBase64StringField recebe o base64String tratado da ultima foto tirada
function tirarFoto() {
    Webcam.snap(
        function (data_uri) {
            let img = document.createElement("img");
            img.setAttribute("src", `${data_uri}`);
            img.setAttribute("class", "center-block");
            img.setAttribute("width", "140px");
            img.setAttribute("height", "110px");

            let br1 = document.createElement("br");
            let br2 = document.createElement("br");

            let inputButton = document.createElement("input");
            inputButton.setAttribute("type", "button");
            inputButton.setAttribute("class", "btn btn-primary");
            inputButton.setAttribute("value", "Descartar");
            inputButton.setAttribute("onClick", "descartarFoto()");

            document.getElementById('resultadoImagem').innerHTML = "";
            document.getElementById('resultadoImagem').appendChild(img);
            document.getElementById('resultadoImagem').appendChild(br1);
            document.getElementById('resultadoImagem').appendChild(br2);
            document.getElementById('resultadoImagem').appendChild(inputButton);
            document.getElementById('imagemBase64StringField').value = data_uri.split(",")[1];
        }
    );
}

// Limpa a div resultadoImagem e do input imagemBase64StringField
function descartarFoto() {
    document.getElementById('resultadoImagem').innerHTML = "";
    document.getElementById('imagemBase64StringField').value = "";
}

// Obtem arquivo selecionado no input file
// #imagemBase64StringField recebe o base64String tratado da ultima foto tirada
function obterArquivoInputFile(elemento) {
    const file = elemento.files[0];
    const reader = new FileReader();
    reader.onloadend = function () {
        document.getElementById('imagemBase64StringField').value = reader.result.split(",")[1];
    }
    reader.readAsDataURL(file);
}