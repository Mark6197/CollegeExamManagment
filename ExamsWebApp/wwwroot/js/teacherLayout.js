$(document).ready(function () {

    //Adding a scroll bar to the sidebar menu in case it will be longer than the screen
    $("#sidebar").mCustomScrollbar({
        theme: "minimal"
    });

    //Signing to the Hamburger button click event 
    $('#sidebarCollapse').on('click', function () {
        //Adding and removing .active class to the sidebar <nav> and the content <div> so it will open and close
        $('#sidebar, #content').toggleClass('active');
        $(this).toggleClass('active');//this refers to the Hamburger button that is changed on click

        //Adding and removing .show class to the dropdowns in order to close them when we close the <nav> side bar
        $('.collapse.show').toggleClass('show');

        //Set the attribue aria-expanded=true to be false
        $('a[aria-expanded=true]').attr('aria-expanded', 'false');
    });
});
