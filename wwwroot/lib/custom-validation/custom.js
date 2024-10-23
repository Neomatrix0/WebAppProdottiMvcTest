 //appena commentato
$(document).ready(function () {
  // Metti a fuoco il primo campo con la classe input-validation-error
  $("input.input-validation-error, select.input-validation-error")
    .first()
    .focus();

  // Applica la logica di validazione durante l'interazione con gli input
  $("input, select").on("blur keyup", function () {
    if ($(this).val().trim() === "") {
      // Se il campo è vuoto, aggiungi la classe input-validation-error e rimuovi input-validation-valid
      $(this)
        .removeClass("input-validation-valid")
        .addClass("input-validation-error")
        .next(".invalid-icon")
        .show()
        .next(".valid-icon")
        .hide();
    } else if ($(this).hasClass("input-validation-error")) {
      // Se ci sono errori di validazione, mantieni input-validation-error
      $(this)
        .removeClass("input-validation-valid")
        .addClass("input-validation-error")
        .next(".invalid-icon")
        .show()
        .next(".valid-icon")
        .hide();
    } else {
      // Se il campo è correttamente compilato, rimuovi input-validation-error e aggiungi input-validation-valid
      $(this)
        .removeClass("input-validation-error")
        .addClass("input-validation-valid")
        .next(".invalid-icon")
        .hide()
        .next(".valid-icon")
        .show();
    }
  });
});  

/*

$(document).ready(function () {
    // Metti a fuoco il primo campo con la classe input-validation-error
    $("input.input-validation-error, select.input-validation-error").first().focus();

    // Applica la logica di validazione durante l'interazione con gli input
    $("input, select").on("blur keyup", function () {
        if ($(this).val().trim() === "") {
            // Se il campo è vuoto, aggiungi la classe input-validation-error e rimuovi input-validation-valid
            $(this).removeClass("input-validation-valid")
                   .addClass("input-validation-error")
                   .next(".invalid-icon").show()   // Mostra l'icona di errore
                   .siblings(".valid-icon").hide(); // Nasconde l'icona di validità
        } else if ($(this).hasClass("input-validation-error")) {
            // Se ci sono errori di validazione, mantieni input-validation-error
            $(this).removeClass("input-validation-valid")
                   .addClass("input-validation-error")
                   .next(".invalid-icon").show()   // Mostra l'icona di errore
                   .siblings(".valid-icon").hide(); // Nasconde l'icona di validità
        } else {
            // Se il campo è correttamente compilato, rimuovi input-validation-error e aggiungi input-validation-valid
            $(this).removeClass("input-validation-error")
                   .addClass("input-validation-valid")
                   .next(".invalid-icon").hide()    // Nasconde l'icona di errore
                   .siblings(".valid-icon").show();  // Mostra l'icona di validità
        }
    });
});
*/
