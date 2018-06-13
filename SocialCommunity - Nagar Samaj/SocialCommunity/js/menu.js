
<!-- /menu/-->
$(document).ready(function (){
$("#firstpane p.menu_head").click(function(){
$(this).css({backgroundImage:"url(images/down.png)"}).next("div.menu_body").slideToggle(300).siblings("div.menu_body").slideUp("slow");
$(this).siblings().css({backgroundImage:"url(images/left.png)"});
});

$("#secondpane p.menu_head").mouseover(function(){
$(this).css({backgroundImage:"url(images/down.png)"}).next("div.menu_body").slideDown(500).siblings("div.menu_body").slideUp("slow");
$(this).siblings().css({backgroundImage:"url(images/left.png)"});
});
});

<!-- /menu 2/-->

$(document).ready(function (){
$("#firstpane p.menu_head2").click(function(){
$(this).css({backgroundImage:"url(images/down2.png)"}).next("div.menu_body2").slideToggle(300).siblings("div.menu_body2").slideUp("slow");
$(this).siblings().css({backgroundImage:"url(images/left2.png)"});
});

$("#secondpane p.menu_head2").mouseover(function(){
$(this).css({backgroundImage:"url(images/down2.png)"}).next("div.menu_body2").slideDown(500).siblings("div.menu_body2").slideUp("slow");
$(this).siblings().css({backgroundImage:"url(images/left2.png)"});
});
});


<!-- /menu 3/-->

$(document).ready(function (){
$("#firstpane p.menu_head3").click(function(){
$(this).css({backgroundImage:"url(images/down3.png)"}).next("div.menu_body3").slideToggle(300).siblings("div.menu_body3").slideUp("slow");
$(this).siblings().css({backgroundImage:"url(images/left3.png)"});
});

$("#secondpane p.menu_head3").mouseover(function(){
$(this).css({backgroundImage:"url(images/down3.png)"}).next("div.menu_body3").slideDown(500).siblings("div.menu_body3").slideUp("slow");
$(this).siblings().css({backgroundImage:"url(images/left3.png)"});
});
});
