$(document).ready(()=>
{
    
    let idMenuItem = commonItemsMap.get(document.title);
    
    fillValuesFromMap(commonItemsMap, fillMenuItems);
    fillValuesFromMap(commonRefsMap, fillItemRefs);
    
    if(idMenuItem === undefined) {
        if(userItemsMap.get(document.title) !== undefined) {
            fillValuesFromMap(userItemsMap, fillMenuItems);
            fillValuesFromMap(userRefsMap, fillItemRefs);    
        }
    }
    
    
    switch (document.title)
    {
        case otherItemNames.RegistrationItem:
        {
            $(itemIds.FifthItem).text(document.title);
            idMenuItem = itemIds.FifthItem;
            
            break;
        }
        case otherItemNames.StatisticsItem:
        {
            buildBarChart();
            buildPieChart('doughnut');
            buildPieChart('pie');

            break;
        }
        case otherItemNames.TicketingItem:
        {
            $(itemIds.FourthItem).text("Билет");
            idMenuItem = itemIds.FourthItem;
            loadCinemaHall();

            break;
        }
        case otherItemNames.InterviewItem:
        {
            $(itemIds.FifthItem).text(document.title);
            idMenuItem = itemIds.ThirdItem;

            break;
        }
    }
    if(movieStudioItems.includes(document.title)) {
        $(itemIds.FifthItem).text(document.title);
        idMenuItem = itemIds.FifthItem;
    }
        
    $(".menu_item").removeClass(activeClassName);
    $(idMenuItem).addClass(activeClassName);
        
});
