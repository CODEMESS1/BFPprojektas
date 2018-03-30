var selectedCompetitors = [];

function pageLoad() {
    var ListBox1 = document.getElementById("competitors_lstbox");

    for (var i = 0; i < ListBox1.length; i++) {
        selectedCompetitors[i] = ListBox1.options[i].selected;
    }
}

function ListBoxClient_SelectionChanged(sender, args) {
    var scrollPosition = sender.scrollTop;

    for (var i = 0; i < sender.length; i++) {
        if (sender.options[i].selected) selectedCompetitors[i] = !selectedCompetitors[i];

        sender.options[i].selected = selectedCompetitors[i] === true;
    }

    sender.scrollTop = scrollPosition;
}