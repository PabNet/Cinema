$(document).ready(()=>
{
    activeClassName = "active";
    let idMenuItem;
    
    switch (document.title)
    {
        case "Главная":
        case "Личный кабинет":
        {
            idMenuItem = "item1";
            
            break;
        }
        case "О кинотеатрах":
        {
            idMenuItem = "item2";

            break;
        }
        case "Работа":
        {
            idMenuItem = "item3";

            break;
        }
        default:
        case "Афиша":
        {
            idMenuItem = "item4";

            break;
        }
        case "Регистрация":
        case "Вход":
        {
            idMenuItem = "item5";

            break;
        }
    }
    $(".menu_item").removeClass(activeClassName);
    $('#' + idMenuItem).addClass(activeClassName);
    
});
