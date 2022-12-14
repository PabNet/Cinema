const itemIds = {
    FirstItem: "#item1",
    SecondItem: "#item2",
    ThirdItem: "#item3",
    FourthItem: "#item4",
    FifthItem: "#item5",
}

const movieStudioItems = ['Фильмы', 'Киносеансы', 'Еда', 'Сервисы', 'Вакансии', 'Роли', 'Новости', 'Кинозалы'];

const otherItemNames = {
    RegistrationItem: "Регистрация",
    StatisticsItem: "Статистика",
    TicketingItem: "Оформление билета",
    InterviewItem: "Интервью",
}

const itemCommonNames = {
    FirstItemName: "Главная",
    SecondItemName: "О кинотеатрах",
    ThirdItemName: "Полезное",
    FourthItemName: "Афиша",
    FifthItemName: "Вход",
}

const itemUserNames = {
    FirstItemName: "Личный кабинет",
    SecondItemName: "Статистика",
    ThirdItemName: "Чат",
    FourthItemName: "Пользователи",
    FifthItemName: "Киномастерская",
}

const userRefs = {
    FirstItemRef: "/PersonalOffice",
    SecondItemRef: "/Statistics",
    ThirdItemRef: "/Chat",
    FourthItemRef: "/UserStudio",
    FifthItemRef: "/MovieStudio",
}

const commonRefs = {
    FirstItemRef: "/",
    SecondItemRef: "/CinemasInformation",
    ThirdItemRef: "/Useful",
    FourthItemRef: "/Billboard",
    FifthItemRef: "/Authorization",
}

const commonItemsMap = new Map([
    [itemCommonNames.FirstItemName, itemIds.FirstItem],
    [itemCommonNames.SecondItemName, itemIds.SecondItem],
    [itemCommonNames.ThirdItemName, itemIds.ThirdItem],
    [itemCommonNames.FourthItemName, itemIds.FourthItem],
    [itemCommonNames.FifthItemName, itemIds.FifthItem],
]);

const commonRefsMap = new Map([
    [commonRefs.FirstItemRef, itemIds.FirstItem],
    [commonRefs.SecondItemRef, itemIds.SecondItem],
    [commonRefs.ThirdItemRef, itemIds.ThirdItem],
    [commonRefs.FourthItemRef, itemIds.FourthItem],
    [commonRefs.FifthItemRef, itemIds.FifthItem],
]);

const userItemsMap = new Map([
    [itemUserNames.FirstItemName, itemIds.FirstItem],
    [itemUserNames.SecondItemName, itemIds.SecondItem],
    [itemUserNames.ThirdItemName, itemIds.ThirdItem],
    [itemUserNames.FourthItemName, itemIds.FourthItem],
    [itemUserNames.FifthItemName, itemIds.FifthItem],
]);

const userRefsMap = new Map([
    [userRefs.FirstItemRef, itemIds.FirstItem],
    [userRefs.SecondItemRef, itemIds.SecondItem],
    [userRefs.ThirdItemRef, itemIds.ThirdItem],
    [userRefs.FourthItemRef, itemIds.FourthItem],
    [userRefs.FifthItemRef, itemIds.FifthItem],
]);

activeClassName = "active";

function fillMenuItems(selector, text) {
    $(selector).text(text);
}

function fillItemRefs(selector, ref) {
    $(selector).attr("href", ref);
}

function fillValuesFromMap(map, callback) {
    map.forEach((value, key, map) => {
        callback(value, key);
    });
}