var myProject = new Object();

//Этот метод вызывается при старте
myProject.Initialize = function () {
    
    myProject.Hash = location.hash.substr(1);

    //Если hash пуст грузим страницу main
    if (!myProject.Hash) {
        myProject.ShowInContent('content/main.html');
    }
    else {
        //Если hash не пуст грузим что есть
        //Приводим к виду для загрузки
        toLoad = "content/" + myProject.Hash + ".html";
        myProject.ShowInContent(toLoad);
    }

    //Привязываем ко всем ссылкам блока nav обработчик
    $('nav a').click(function () {
        myProject.ShowInContent(this.href);
        return false;
    })
}

//Этот метод скрывает старое содержание и показывает новое
myProject.ShowInContent = function (toLoad) {
    $('content').hide('fast');
    $('content').load(toLoad, function (response, status, xhr) { if (status == "error") { $('content').html("<h1> Error: " + xhr.status.toString()) + "</h1>" } });
    $('content').show('normal');

    //Выделяем название файла и записываем в hash
    var start = toLoad.lastIndexOf('/') + 1;
    var end = toLoad.length - 5;
    window.location.hash = toLoad.substr(start, end - start);
}

//Просто для инициализации
$(myProject.Initialize);