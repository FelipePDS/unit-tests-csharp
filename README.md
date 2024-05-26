<h1 align="center">Testes unitários em .NET 🧪</h1>

<p align="center">
  <a href="https://github.com/FelipePDS/Breadcrumbsunit-tests-dotnet/blob/main/LICENSE"><img src="https://img.shields.io/github/license/Felipepds/unit-tests-dotnet?style=for-the-badge"/></a> 
  <img src="https://img.shields.io/github/last-commit/FelipePDS/unit-tests-dotnet?color=fb1569&style=for-the-badge"/>
  <img src="https://img.shields.io/static/v1?label=.NET&message=6.0&color=512BD4&style=for-the-badge"/> 
  <img src="https://img.shields.io/static/v1?label=Unit+Test&message=XUnit&color=000000&style=for-the-badge"/>  <br>
  <img src="https://img.shields.io/static/v1?label=Web+Unit+Test&message=Selenium&color=42b02a&style=for-the-badge"/> 
  <img src="https://img.shields.io/static/v1?label=Pipeline&message=Azure+DevOps&color=0078d4&style=for-the-badge"/> 
</p>

<br>
<h2 align="center">Tópicos</h2>

<p align="center">
  <a href="#objective">🎯 Objetivo</a> &bull; 
  <a href="#technologies">:computer: Tecnologias</a> &bull; 
  <a href="#clone">:open_file_folder: Clonar subdiretórios</a> <br>
  <a href="#exercises">:pushpin: Mini projetos e exercícios do curso</a> &bull; 
  <a href="#author">:bust_in_silhouette: Autor</a> &bull; 
  <a href="#license">:page_with_curl: Licensa</a>
</p>

<br>
<h2 id="objective" align="center">🎯 Objetivo</h2>

<p align="center">
    Testes unitários em .NET feitos através do <a href="https://cursos.alura.com.br/formacao-testes-em-dotnet">curso Alura:</a>
    <br>
    <b>"Domine os testes em .NET usando XUnit, TDD, Selenium e Azure Devops."</b>
</p>

<h4 align="center">Passo 1:</h4>
<p align="center"><img align="center" src="https://github.com/FelipePDS/unit-tests-dotnet/blob/main/.github/curso_step1.png"></p>

<h4 align="center">Passo 2:</h4>
<p align="center"><img align="center" src="https://github.com/FelipePDS/unit-tests-dotnet/blob/main/.github/curso_step2.png"></p>

<h4 align="center">Passo 3:</h4>
<p align="center"><img align="center" src="https://github.com/FelipePDS/unit-tests-dotnet/blob/main/.github/curso_step3.png"></p>

<h4 align="center">Passo 4:</h4>
<p align="center"><img align="center" src="https://github.com/FelipePDS/unit-tests-dotnet/blob/main/.github/curso_step4.png"></p>

<h2 id="technologies" align="center">💻 Tecnologias</h2>

<p align="center">
  <a href="https://dotnet.microsoft.com/learn/csharp">C#</a>
  &bull; <a href="https://dotnet.microsoft.com/pt-br/download/dotnet/6.0">.NET v6.0</a>
  &bull; <a href="https://www.docker.com/">Docker</a>
  &bull; <a href="https://xunit.net/">XUnit</a>
  &bull; <a href="https://www.selenium.dev/">Selenium</a> <br>
  <a href="https://learn.microsoft.com/pt-br/training/modules/run-quality-tests-build-pipeline/">Azure Pipeline - Unit Tests</a>
  &bull; <a href="https://visualstudio.microsoft.com/pt-br/downloads/">Code Editor - Visual Studio 2022</a>
</p>

<br>
<h2 align="center" id="clone">:open_file_folder: Clonar subdiretórios</h2>

<p align="center">Se quiser clonar um dos exercícios (subdiretórios), apenas tenha <kbd><a href="https://git-scm.com/downloads">git bash</a></kbd> em sua máquina para executar os seguintes commandos.</p>

```bash
# crie uma pasta com o nome de exercícios e entre nele
$ mkdir name-dir && cd name-dir

# inicie um repositório git para acessar o repositório
$ git init

# rastreie o repositório
$ git remote add -f origin https://github.com/FelipePDS/unit-tests-dotnet

# sparse checkout ativo
$ git config core.sparseCheckout true

# crie um arquivo no caminho: .git/unit-tests-dotnet/sparse-checkout
# e insira o nome do subdiretório que você deseja clonar
$ echo 'nameOfTheSubdirectory' >> .git/unit-tests-dotnet/sparse-checkout

# dê um pull no subdiretório
$ git pull origin main
```
<blockquote>Fonte: <a href="https://terminalroot.com.br/2019/09/como-clonar-somente-um-subdiretorio-com-git-ou-svn.html">terminalroot.com.br</a></blockquote>

<p>Se você deseja clonar o projeto inteiro: <code>$ git clone https://github.com/FelipePDS/unit-tests-dotnet.git</code></p>

<br>
<h2 id="exercises" align="center">:pushpin: Mini projetos e exercícios do curso</h2>

<table align="center">
  <tr align="center">
    <th>REPO</th>
    <th>DESCRIÇÃO</th>
    <th>DATA</th>
    <th>STATUS</th>
  </tr>

  <tr align="center">
    <td><kbd><a href="https://github.com/FelipePDS/unit-tests-dotnet/tree/main/JornadaMilhas">JornadaMilhas</a></kbd></td>
    <td>Introdução aos testes unitários com o XUnit em um projeto em C#, simulando uma consulta de viagens.</td>
    <td>23/05/2024</td>
    <td>✅</td>
  </tr>

  <tr align="center">
    <td><kbd><a href="https://github.com/FelipePDS/unit-tests-dotnet/tree/main/GerenciadorMusicas">GerenciadorMusicas</a></kbd></td>
    <td>Projeto com o objetivo de cumprir uma lista de exercícios sobre a introdução dos testes usando o XUnit.</td>
    <td>24/05/2024</td>
    <td>✅</td>
  </tr>
</table>

<br>
<h2 align="center" id="author">:bust_in_silhouette: Autor</h2>

<p align="center">:pencil: by <a href="https://felipepds.github.io//">FelipePDS</a></p>
<p align="center"><a href="https://www.linkedin.com/in/felipe-p-da-silva-a55b891ba/?lipi=urn%3Ali%3Apage%3Ad_flagship3_feed%3BiErPy3g7Q1KGOaD%2BsGw%2Fpg%3D%3D"><img src="https://img.shields.io/static/v1?label=+&message=Felipe+P.+Da+Silva&color=0A66C2&style=flat&logo=linkedin&logoColor=white"/></a> <a href="https://twitter.com/FelipePintoDaS1"><img src="https://img.shields.io/static/v1?label=+&message=@FelipePintoDaS1&color=1DA1F2&style=flat&logo=twitter&logoColor=white"/></a> <img src="https://img.shields.io/static/v1?label=+&message=felipepdasilva66@gmail.com&color=EA4335&style=flat&logo=gmail&logoColor=white"/></p>

<br>
<h2 align="center" id="license">:page_with_curl: Licença</h2>

<p align="center"><a href="https://github.com/FelipePDS/unit-tests-dotnet/blob/main/LICENSE">MIT License</a> &nbsp;&bull;&nbsp; &copy; FelipePDS</p>
