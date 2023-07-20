$(document).ready(function () {
    let storageCount = $('.storage-items') == undefined ? 0 : $('.storage-items').length;

    function closeModal() {
        setTimeout(function () {
            $('#checkModal').modal('hide');
            location.reload();
        }, 3000)
    }

    function showAlert(content) {
        $('#myAlert').css('display', 'block');
        $('#myAlert').addClass('.alert-warning');
        $('#myAlert').html(content);
        setTimeout(function () {
            $('#myAlert').css('display', 'none');
        }, 3000)
    }

    $('#color-add').click(function () {
        let colorCount = $('.color-items') == undefined ? 0 : $('.color-items').length;

        if (colorCount < 10) {
            $('#color-content').append(`<div class="color-items" id="color-${colorCount}">
                            <input class="color-input color-new" type="text" placeholder="Thêm màu"/>
                            <input class="delete-color" type="button" value="Xóa"/>
                        </div>`);
        } else {
            showAlert('Đã đạt giới hạn của lựa chọn màu sắc!');
        }
    });

    $('#storage-add').click(function () {
        let storageCount = $('.storage-items') == undefined ? 0 : $('.storage-items').length;

        if (storageCount < 10) {
            $('#storage-content').append(`<div class="storage-items" id="storage-${storageCount}">
                            <input class="storage-input storage-new" type="text" placeholder="Thêm bộ nhớ"/>
                            <input class="delete-storage" type="button" value="Xóa"/>
                        </div>`);
        } else {
            showAlert('Đã đạt giới hạn của lựa chọn bộ nhớ!');
        }
    });

    $('#description').summernote({
        placeholder: 'Mô tả sản phẩm',
        tabsize: 2,
        height: 450,
        width: 955,
    });

    $('#save').click(function () {
        let color = $('.color-new');
        let storage = $('.storage-new');

        let colorData = Array.prototype.slice.call(color).map(function (e) {
            return e.value;
        });

        let storageData = Array.prototype.slice.call(storage).map(function (e) {
            return e.value;
        });
        //Thông tin cơ bản
        let cid = $('select[name=cid]').val().trim();
        let pid = $('input[name=pid]').val().trim();
        let name = $('input[name=pname]').val().trim();
        let image = $('input[name=image]').val().trim();
        let price = $('input[name=price]').val().trim();
        let amount = $('input[name=amount]').val().trim();
        let description = $('#description').summernote('code');
        //Thông tin cấu hình
        let screen = $('input[name=screen]').val().trim();
        let os = $('input[name=os]').val().trim();
        let rearcam = $('input[name=rearcam]').val().trim();
        let frontcam = $('input[name=frontcam]').val().trim();
        let soc = $('input[name=soc]').val().trim();
        let ram = $('input[name=ram]').val().trim();
        let sim = $('input[name=sim]').val().trim();
        let battery = $('input[name=battery]').val().trim();


        $('#checkModal').modal('show');
        $('#checkModalLabel').html(`Thêm mới!`);
        $('#bodyContent').html(`Bạn có muốn muốn tạo?`);
        $('#confirmAction').click(function () {
            $.ajax({
                type: "post",
                url: "/Admin/AddNewProduct",
                data: {
                    Pid: pid,
                    Cid: cid,
                    Name: name,
                    Image: image,
                    Price: price,
                    Description: description,
                    Amount: amount,
                    Screen: screen,
                    Os: os,
                    Rearcam: rearcam,
                    Frontcam: frontcam,
                    Soc: soc,
                    Ram: ram,
                    Sim: sim,
                    Battery: battery,
                    colors: JSON.stringify(colorData),
                    storages: JSON.stringify(storageData)
                },
                success: function (response) {
                    $('#checkModal').modal('hide');
                    if (response.status === "Success") {
                        showAlert(response.content);
                        parent.remove();
                    } else {
                        showAlert(response.content);
                    };
                }
            });
        });


    });
})


