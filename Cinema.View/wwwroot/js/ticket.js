function loadCinemaHall() {
    cinemaHall1 = {
        row: [10, 20, 30, 30, 30, 30, 30, 30, 30, 30, 30]
    },cinemaHallMap = '';

    $.each(cinemaHall1.row, function(row, numberOfSeats) {
        cinemaHallRow = '';
        for (i = 1; i <= numberOfSeats; i++) {
            cinemaHallRow += '<div class="seat" data-row="' +
                i + '" data-seat="' +
                i + '">&nbsp;</div>';
        }

        cinemaHallMap += cinemaHallRow + '<div class="passageBetween">&nbsp;</div>';
    });
    
    $('.zal1').html(cinemaHallMap);
    $('.seat').on('click', function(e) {
        $(e.currentTarget).toggleClass('bay');

        showBaySeat();
    });

    function showBaySeat() {
        result = '';
        $.each($('.seat.bay'), function(key, item) {
            result += '<div class="ticket">Ряд: ' +
                $(item).data().row + ' Место:' +
                $(item).data().seat + '</div>';
        });

        $('.result').html(result);
    }
}