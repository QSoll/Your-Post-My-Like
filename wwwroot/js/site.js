document.addEventListener("DOMContentLoaded", function () {
  const botoesCurtir = document.querySelectorAll(".interacoes-compactas");

  botoesCurtir.forEach(area => {
    const coracao = area.querySelector(".coração");
    const contador = area.querySelector(".contador-curtidas");

    coracao.addEventListener("click", () => {
      let total = parseInt(contador.textContent);

      if (!coracao.classList.contains("curtido")) {
        coracao.classList.add("curtido");
        coracao.textContent = "❤️";
        contador.textContent = (total + 1).toString();
      } else {
        coracao.classList.remove("curtido");
        coracao.textContent = "🤍";
        contador.textContent = (total - 1).toString();
      }
    });
  });
});
