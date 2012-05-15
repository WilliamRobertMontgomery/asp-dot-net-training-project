var myProject = new Object();

//���� ����� ���������� ��� ������
myProject.Initialize = function () {
    
    myProject.Hash = location.hash.substr(1);

    //���� hash ���� ������ �������� main
    if (!myProject.Hash) {
        myProject.ShowInContent('content/main.html');
    }
    else {
        //���� hash �� ���� ������ ��� ����
        //�������� � ���� ��� ��������
        toLoad = "content/" + myProject.Hash + ".html";
        myProject.ShowInContent(toLoad);
    }

    //����������� �� ���� ������� ����� nav ����������
    $('nav a').click(function () {
        myProject.ShowInContent(this.href);
        return false;
    })
}

//���� ����� �������� ������ ���������� � ���������� �����
myProject.ShowInContent = function (toLoad) {
    $('content').hide('fast');
    $('content').load(toLoad, function (response, status, xhr) { if (status == "error") { $('content').html("<h1> Error: " + xhr.status.toString()) + "</h1>" } });
    $('content').show('normal');

    //�������� �������� ����� � ���������� � hash
    var start = toLoad.lastIndexOf('/') + 1;
    var end = toLoad.length - 5;
    window.location.hash = toLoad.substr(start, end - start);
}

//������ ��� �������������
$(myProject.Initialize);