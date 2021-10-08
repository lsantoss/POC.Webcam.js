// Variáveis globais
var foto = "";
var fotoEditada = "";

// Ao carregar a página configura a webcam
window.onload = function () {
    Webcam.set({
        width: 225,
        height: 225,
        image_format: 'png'
    });
    Webcam.attach('#divWebcam');
}

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

    foto = "";
    fotoEditada = "";
    document.getElementById('imagemBase64StringField').value = "";

    Webcam.set({
        width: 225,
        height: 225,
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

    let divUploadBtnWrapper = document.createElement("div");
    divUploadBtnWrapper.setAttribute("class", "upload-btn-wrapper");

    let btnUpload = document.createElement("button");
    btnUpload.setAttribute("class", "btn btnUpload");
    btnUpload.setAttribute("id", "btnInputFile");

    let imgBtnUpload = document.createElement("img");
    imgBtnUpload.setAttribute("src", "/images/upload-nuvem.png");
    imgBtnUpload.style.cssText = "width:90px; height:90px;";

    let brBtnUpload = document.createElement("br");

    let pBtnUpload = document.createElement("p");
    pBtnUpload.innerHTML = "Arraste a imagem aqui<br/> ou <br/> Clique para encontrar uma<br/> no dispositivo";

    let inputFile = document.createElement("input");
    inputFile.setAttribute("type", "file");
    inputFile.setAttribute("accept", "image/*");
    inputFile.setAttribute("onchange", "obterArquivoInputFile(this)");

    divPainelDefault.appendChild(divColMd12);
    divColMd12.appendChild(divPainelHeading);
    divColMd12.appendChild(divPainelBody);
    divPainelBody.appendChild(p);
    divPainelBody.appendChild(divUploadBtnWrapper);
    btnUpload.append(imgBtnUpload);
    btnUpload.append(brBtnUpload);
    btnUpload.append(pBtnUpload);
    divUploadBtnWrapper.appendChild(btnUpload);
    divUploadBtnWrapper.appendChild(inputFile);

    document.getElementById('divEscolha').innerHTML = "";
    document.getElementById('divEscolha').appendChild(divPainelDefault);

    foto = "";
    fotoEditada = "";
    document.getElementById('imagemBase64StringField').value = "";
}

// Captura imagem ao clicar no botão "Tirar foto"
// Mostra resultadoImagem na página
// #imagemBase64StringField recebe o base64String tratado da ultima foto tirada
function tirarFoto() {
    Webcam.snap(
        function (imagemBase64String) {
            foto = imagemBase64String;
            fotoEditada = imagemBase64String;
            mostarImagemModalEdicao(imagemBase64String);
            $('#modalPersonalizacaoImagem').modal('show');
        }
    );
}

// Cria elemento e mostra imagem no modal de edição
function mostarImagemModalEdicao(imagemBase64String) {
    let img = document.createElement("img");
    img.setAttribute("src", `${imagemBase64String}`);
    img.setAttribute("class", "mt-4 mb-2");
    img.style.cssText = "width:55%; heigth:55%; margin-left:110px;";

    document.getElementById('modalBodyPersonalizacaoImagem').innerHTML = "";
    document.getElementById('modalBodyPersonalizacaoImagem').appendChild(img);
}

// Rotação de imagem para direita
function girarParaDireita() {
    var imgOriginal = new Image();
    imgOriginal.src = fotoEditada;

    var canvas = document.createElement("canvas");

    if (imgOriginal.height > imgOriginal.width) {
        canvas.width = imgOriginal.height;
        canvas.height = imgOriginal.height;
    }

    if (imgOriginal.width > imgOriginal.height) {
        canvas.width = imgOriginal.width;
        canvas.height = imgOriginal.width;
    }

    if (imgOriginal.width === imgOriginal.height) {
        canvas.width = imgOriginal.width;
        canvas.height = imgOriginal.height;
    }

    var ctx = canvas.getContext("2d");
    ctx.translate(canvas.width / 2, canvas.height / 2);

    // cria imagem inicial
    var image = document.createElement("img");
    image.src = imgOriginal.src;

    // limpa canvas, rotaciona e desenha imagem no centro
    ctx.clearRect(-canvas.width, -canvas.height, canvas.width * 2, canvas.height * 2);
    ctx.rotate(90 * Math.PI / 180);
    ctx.drawImage(image, -image.width / 2, -image.width / 2);

    // cria nova imagem no html
    var img = document.createElement('img');
    img.src = canvas.toDataURL("image/png");
    fotoEditada = img.src;
    mostarImagemModalEdicao(fotoEditada);
}

// Rotação de imagem para esquerda
function girarParaEsquerda() {
    var imgOriginal = new Image();
    imgOriginal.src = fotoEditada;

    var canvas = document.createElement("canvas");

    if (imgOriginal.height > imgOriginal.width) {
        canvas.width = imgOriginal.height;
        canvas.height = imgOriginal.height;
    }

    if (imgOriginal.width > imgOriginal.height) {
        canvas.width = imgOriginal.width;
        canvas.height = imgOriginal.width;
    }

    if (imgOriginal.width === imgOriginal.height) {
        canvas.width = imgOriginal.width;
        canvas.height = imgOriginal.height;
    }

    var ctx = canvas.getContext("2d");
    ctx.translate(canvas.width / 2, canvas.height / 2);

    // cria imagem inicial
    var image = document.createElement("img");
    image.src = imgOriginal.src;

    // limpa canvas, rotaciona e desenha imagem no centro
    ctx.clearRect(-canvas.width, -canvas.height, canvas.width * 2, canvas.height * 2);
    ctx.rotate(-90 * Math.PI / 180);
    ctx.drawImage(image, -image.width / 2, -image.width / 2);

    // cria nova imagem no html
    var img = document.createElement('img');
    img.src = canvas.toDataURL("image/png");
    fotoEditada = img.src;
    mostarImagemModalEdicao(fotoEditada);
}

/////// Aumenta o brilho da imagem
function aumentarBrilho() {
    var imgOriginal = new Image();
    imgOriginal.src = fotoEditada;

    var canvas = document.createElement("canvas");
    canvas.width = imgOriginal.width;
    canvas.height = imgOriginal.height;

    var ctx = canvas.getContext("2d");

    // cria imagem inicial
    var image = document.createElement("img");
    image.src = imgOriginal.src;

    // limpa canvas, rotaciona e aplica brilho
    ctx.filter = "brightness(105%)";
    ctx.drawImage(image, 0, 0);

    // cria nova imagem no html
    var img = document.createElement('img');
    img.src = canvas.toDataURL("image/png");
    fotoEditada = img.src;
    mostarImagemModalEdicao(fotoEditada);
}

// Diminui o brilho da imagem
function diminuirBrilho() {
    var imgOriginal = new Image();
    imgOriginal.src = fotoEditada;

    var canvas = document.createElement("canvas");
    canvas.width = imgOriginal.width;
    canvas.height = imgOriginal.height;

    var ctx = canvas.getContext("2d");

    // cria imagem inicial
    var image = document.createElement("img");
    image.src = imgOriginal.src;

    // limpa canvas, rotaciona e aplica brilho
    ctx.filter = "brightness(95%)";
    ctx.drawImage(image, 0, 0);

    // cria nova imagem no html
    var img = document.createElement('img');
    img.src = canvas.toDataURL("image/png");
    fotoEditada = img.src;
    mostarImagemModalEdicao(fotoEditada);
}

// Imagem para preto e branco
function adicionarFiltroPretoBranco() {
    var imgOriginal = new Image();
    imgOriginal.src = fotoEditada;

    var canvas = document.createElement("canvas");
    canvas.width = imgOriginal.width;
    canvas.height = imgOriginal.height;

    var ctx = canvas.getContext("2d");

    // cria imagem inicial
    var image = document.createElement("img");
    image.src = imgOriginal.src;

    // limpa canvas, rotaciona e aplica brilho
    ctx.filter = "grayscale(100%)";
    ctx.drawImage(image, 0, 0);

    // cria nova imagem no html
    var img = document.createElement('img');
    img.src = canvas.toDataURL("image/png");
    fotoEditada = img.src;
    mostarImagemModalEdicao(fotoEditada);
}

// Restaura a imagem original
function desfazerModificacoes() {
    fotoEditada = foto;
    mostarImagemModalEdicao(fotoEditada);
}

// Descarta todas as modificações feitas na imagem
function cancelarModificacoes() {
    foto = "";
    fotoEditada = "";
    document.getElementById('modalBodyPersonalizacaoImagem').innerHTML = "";
}

// Mostra resultado da imagem após ser editada com filtro no modal
function confimarModificacoes() {
    let br1 = document.createElement("br");

    let img = document.createElement("img");
    img.setAttribute("src", `${fotoEditada}`);
    img.setAttribute("class", "center-block");
    img.setAttribute("width", "225px");
    img.setAttribute("height", "175px");

    let br2 = document.createElement("br");
    let br3 = document.createElement("br");
    let br4 = document.createElement("br");

    let inputButton = document.createElement("input");
    inputButton.setAttribute("type", "button");
    inputButton.setAttribute("class", "btn btn-primary");
    inputButton.setAttribute("value", "Descartar");
    inputButton.setAttribute("onClick", "descartarFoto()");

    document.getElementById('resultadoImagem').innerHTML = "";
    document.getElementById('resultadoImagem').appendChild(br1);
    document.getElementById('resultadoImagem').appendChild(img);
    document.getElementById('resultadoImagem').appendChild(br2);
    document.getElementById('resultadoImagem').appendChild(br3);
    document.getElementById('resultadoImagem').appendChild(br4);
    document.getElementById('resultadoImagem').appendChild(inputButton);
    document.getElementById('imagemBase64StringField').value = fotoEditada.split(",")[1];
}

// Limpa a div resultadoImagem e do input imagemBase64StringField
function descartarFoto() {
    foto = "";
    fotoEditada = "";
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