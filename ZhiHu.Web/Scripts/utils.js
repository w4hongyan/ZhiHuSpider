var utils = {};
utils.post = function (post_url, post_data, success_callback, error_callback) {
    $.ajax({
        type: "post",
        dataType: "json",
        url: post_url,
        data: post_data,
        success: success_callback,
        error: error_callback
    });
}
