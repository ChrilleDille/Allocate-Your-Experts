const expertUl = $('#experts-ul');
const teamUl = $('#team-ul');
const dropBox = $('#drop-box');
const projectNameHeader = document.getElementById('projectname-header');
var projectId;
const alertBox = $('#alert-box');

appendExpertUl = dto => {
    expertUl.append(`<li class='list-group-item' id='${dto.id}'>
                                                       <div class='card'>
                                                       <div class='card-body userprofile'>
                                                       <img src='images/${dto.gender.toLowerCase()}avatar.png'/>
                                                       <h5>${dto.name}</h5></div>
                                                       <div class='card-footer'></div></div></li>`);
};

appendTeamUl = member => {
    teamUl.append(`<li class='list-group-item' id='${member.expert.id}'>${member.expert.name}</li>`);
};

dragExperts = () => {
    expertUl.children('li').draggable({
        cursor: 'move',
        helper: 'clone',
        revert: false
    });

};

getExperts = () => {
    $.ajax({
        type: 'GET',
        async: false,
        url: '/api/experts',
        error: (xhr, status, error) => {
            alert(xhr.responseText);
        },
        success: (data) => {
            data.forEach(dto => {
                appendExpertUl(dto);
            });
            dragExperts();
        }

    });
};

dropExperts = () => {
    dropBox.droppable({
        hoverClass: 'hover-box',
        drop: (event, ui) => {
            var expertCard = $(ui.draggable);
            $.ajax({
                type: 'POST',
                url: `/api/projects/${projectId}/projectteam`,
                contentType: 'application/json',
                dataType: 'json',
                data: JSON.stringify(
                    {
                        "expert": {
                            "id": expertCard.attr('id')

                        },
                        "role": {
                            "id": "c0aa725f-3804-4fe9-a51f-74c3e7780475"
                        }
                    }
                ),
                success: (data) => {
                    expertCard.remove();
                    appendTeamUl(data);
                    alertBox.show();
                    $('#alert-box-expertname').text(data.expert.name);
                    $('#alert-box-projectname').text(projectNameHeader.innerHTML);
                    expertUl.children('li').addClass('disabled');

                    setTimeout(() => {
                        expertUl.children('li').removeClass('disabled');
                        alertBox.hide();
                    },
                        2000);
                }
            });
        }
    });
};

getProjectTeam = () => {
    $.ajax({
        type: 'GET',
        async: false,
        url: '/api/projects/e7819413-0aa7-4885-b45e-d3a8ecbc4339/projectteam',
        success: (data) => {
            projectId = data.project.id;
            projectNameHeader.innerHTML = data.project.name;
            data.members.forEach(member => {
                appendTeamUl(member);
            });

            dropExperts();
        }
    });
};

$(document).ready(() => {
    alertBox.hide();
    getExperts();
    getProjectTeam();

    var listOfIds = [];
    teamUl.children('li').each(function () {
        listOfIds.push($(this).attr('id'));
    });
    expertUl.children('li').each(function () {
        if (listOfIds.some(id => id === $(this).attr('id'))) {
            $(this).remove();
        }
    });
});
