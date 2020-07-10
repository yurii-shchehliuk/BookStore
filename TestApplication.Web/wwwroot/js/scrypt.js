window.onload = function(){
    let logo = $(".aside");
    let icon = $("#icon");
    const menu  = $(".aside__nav");
    const asideButton = $('.menu-icon-wrapper')
    
    asideButton.on('click',(e)=>{
        e.preventDefault();
        
            menu.slideToggle(500);
            logo.toggleClass("asideShow")
            icon.toggleClass("far fa-times-circle")
            
     })

     document.querySelector('.menu-icon-wrapper').onclick = function(){
        document.querySelector('.menu-icon').classList.toggle('menu-icon-active');
    }
    
}