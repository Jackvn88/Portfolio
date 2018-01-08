(function () {
    $(".img_text").hover(
        function () {
            $(this).css("opacity", "1");
            $(this, ".centered").css("opacity", "1");
            
            
        },
        function () {
            $(this).css("opacity", "0.5");
        }
    );
})();