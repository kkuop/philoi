(function($){
    function processForm( e ){
        var dict = {
        	Search : this["form"]["activity-search"].value,
        };

        $.ajax({
            url: `https://localhost:44376/api/activities/${this["form"]["activity-search"].value}`,
            dataType: 'json',
            type: 'get',
            contentType: 'application/json',
            data: JSON.stringify(dict),
            success: function( data, textStatus, jQxhr ){
                $('#response').html(`${data.map(function(item){
                    return "<span>" + item.name + " </span>";
                }).join("<br>")}`);


            },
            error: function( jqXhr, textStatus, errorThrown ){
                console.log( errorThrown );
            }
        });

        e.preventDefault();
    }

    function processFormFandom( e ) {
        var dict = {
            Search : this["form"]["fandom-search"].value,
        };

        $.ajax({
            url: `https://localhost:44376/api/fandoms/${this["form"]["fandom-search"].value}`,
            dataType: 'json',
            type: 'get',
            contentType: 'application/json',
            data: JSON.stringify(dict),
            success: function( data, textStatus, jQxhr ) {
                $('#response').html(`${data.map(function(item) {
                    return "<span>" + item.name + "</span>";
                }).join("<br>")}`);
            },
            error: function( jqXhr, textStatus, errorThrown ) {
                console.log( errorThrown) ;
            }
        });
        e.preventDefault();
    }

        function processFormMovie( e ) {
        var dict = {
            Search : this["form"]["movie-search"].value,
        };

        $.ajax({
            url: `https://localhost:44376/api/movies/${this["form"]["movie-search"].value}`,
            dataType: 'json',
            type: 'get',
            contentType: 'application/json',
            data: JSON.stringify(dict),
            success: function( data, textStatus, jQxhr ) {
                $('#response').html(`${data.map(function(item) {
                    return "<span>" + item.name + "</span>";
                }).join("<br>")}`);
            },
            error: function( jqXhr, textStatus, errorThrown ) {
                console.log( errorThrown) ;
            }
        });
        e.preventDefault();
    }

        function processFormMusic( e ) {
        var dict = {
            Search : this["form"]["music-search"].value,
        };

        $.ajax({
            url: `https://localhost:44376/api/music/${this["form"]["music-search"].value}`,
            dataType: 'json',
            type: 'get',
            contentType: 'application/json',
            data: JSON.stringify(dict),
            success: function( data, textStatus, jQxhr ) {
                $('#response').html(`${data.map(function(item) {
                    return "<span>" + item.name + "</span>";
                }).join("<br>")}`);
            },
            error: function( jqXhr, textStatus, errorThrown ) {
                console.log( errorThrown) ;
            }
        });
        e.preventDefault();
    }

        function processFormSport( e ) {
        var dict = {
            Search : this["form"]["sport-search"].value,
        };

        $.ajax({
            url: `https://localhost:44376/api/sports/${this["form"]["sport-search"].value}`,
            dataType: 'json',
            type: 'get',
            contentType: 'application/json',
            data: JSON.stringify(dict),
            success: function( data, textStatus, jQxhr ) {
                $('#response').html(`${data.map(function(item) {
                    return "<span>" + item.name + "</span>";
                }).join("<br>")}`);
            },
            error: function( jqXhr, textStatus, errorThrown ) {
                console.log( errorThrown) ;
            }
        });
        e.preventDefault();
    }

    $('#searchBox').keyup( processForm );
    $('#fandomSearchBox').keyup( processFormFandom );
    $('#movieSearchBox').keyup( processFormMovie );
    $('#musicSearchBox').keyup( processFormMusic );
    $('#sportSearchBox').keyup( processFormSport );
})(jQuery);

function setEdit(id1, id2) {
    var input1 = document.getElementById(id1);
    var input2 = document.getElementById(id2);
    input2.value = input1.value;
}

function displaySearchBox() {
    var value = document.getElementById("catDropDown").value;
    var activities = document.getElementById("activitiesBox");
    var fandoms = document.getElementById("fandomsBox");
    var movies = document.getElementById("moviesBox");
    var music = document.getElementById("musicBox");
    var sports = document.getElementById("sportsBox");
    if(value == 'Activities') {
        activities.classList.remove("invis");
        if(fandoms.classList.contains("invis")) {
            
        } else {
            fandoms.classList.add("invis");
        }
        if(movies.classList.contains("invis")) {
            
        } else {
            movies.classList.add("invis");
        }
        if(music.classList.contains("invis")){
            
        } else {
            music.classList.add("invis");
        }
        if(sports.classList.contains("invis")) {
            
        } else {
            sports.classList.add("invis");
        }
    }
    if(value == 'Fandoms') {
        fandoms.classList.remove("invis");
        if(activities.classList.contains("invis")) {
            
        } else {
            activities.classList.add("invis");
        }
        if(movies.classList.contains("invis")) {
            
        } else {
            movies.classList.add("invis");
        }
        if(music.classList.contains("invis")){
            
        } else {
            music.classList.add("invis");
        }
        if(sports.classList.contains("invis")) {
            
        } else {
            sports.classList.add("invis");
        }
    }
    if(value == 'Movies') {
        movies.classList.remove("invis");
        if(fandoms.classList.contains("invis")) {
            
        } else {
            fandoms.classList.add("invis");
        }
        if(activities.classList.contains("invis")) {
            
        } else {
            activities.classList.add("invis");
        }
        if(music.classList.contains("invis")){
            
        } else {
            music.classList.add("invis");
        }
        if(sports.classList.contains("invis")) {
            
        } else {
            sports.classList.add("invis");
        }
    }
    if(value == 'Music') {
        music.classList.remove("invis");
        if(fandoms.classList.contains("invis")) {
            
        } else {
            fandoms.classList.add("invis");
        }
        if(movies.classList.contains("invis")) {
            
        } else {
            movies.classList.add("invis");
        }
        if(activities.classList.contains("invis")){
            
        } else {
            activities.classList.add("invis");
        }
        if(sports.classList.contains("invis")) {
            
        } else {
            sports.classList.add("invis");
        }
    }
    if(value == 'Sports') {
        sports.classList.remove("invis");
        if(fandoms.classList.contains("invis")) {
            
        } else {
            fandoms.classList.add("invis");
        }
        if(movies.classList.contains("invis")) {
            
        } else {
            movies.classList.add("invis");
        }
        if(music.classList.contains("invis")){
            
        } else {
            music.classList.add("invis");
        }
        if(activities.classList.contains("invis")) {
            
        } else {
            activities.classList.add("invis");
        }
    }
}

