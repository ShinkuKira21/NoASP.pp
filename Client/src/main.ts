/* Author(s): Edward Patch */
import './style.css';

const WelcomeAPI = (welcomeID: string, welcomeBodyID: string) => {
      $.ajax({
            cache: false,
            type: 'GET',
            url: 'http://localhost:3000/api',
            accept: 'application/json',
            contentType: 'application/json; charset=utf-8',
            success: (res) => {
                  $(welcomeID).html(res);
                  $(welcomeBodyID).html("To view the ASP.NET Endpoints with <b><u>dotnet run</u></b> (developer mode only (doesn't work with docker))<br/>Click <a href='https://localhost:3000/swagger/index.html'>here!</a> - https://localhost:3000/swagger/index.html");
            },
            error: (req) => console.log(req)
      });
}

const SubmitPost = (id: string, peID: string, cppID: string) => {
      $(id).on('click', () => {
            let post = `"${$('#name').val()}"`;
            JSON.stringify(post)

            $.ajax({
                  cache: false,
                  type: 'POST',
                  url: 'http://localhost:3000/api/PostExample',
                  data: post,
                  contentType: 'application/json; charset=utf-8',
                  success: (res) => $(peID).html(res),
                  error: (req) => console.log(req)
            });

            $.ajax({
                  cache: false,
                  type: 'POST',
                  url: 'http://localhost:3000/api/CPPPost',
                  data: post,
                  contentType: 'application/json; charset=utf-8',
                  success: (res) => $(cppID).html(res),
                  error: (req) => console.log(req)
            });
      });
};

const app = document.querySelector<HTMLDivElement>('#app')!

let welcome: string = "<div id='welcome-res'>Loading...</div>";
let welcomeBody: string = "<div id='welcome-body'></div>";

let form: string = `
    <div id='post-form'>
         <form method="POST">
            <label for="name">Post Your Name: </label>
            <br/>
            <input id="name" type="text" name="username"/>
            <input id="post" type="button" value="Post"/>
        </form>
        <div id="postexample"></div>
        <br/>
        <div id="cpppost"></div>
    </div>
`;

WelcomeAPI('#welcome-res', '#welcome-body');

app.innerHTML = `
  <div class="logo">
        <img id="logo" src="../logo.svg" width="10%" alt="ViteJS"/>
    </div>
    <div class="aspnet-welcome">
      <h1>${welcome}</h1>
      <p>${welcomeBody}</p>
      ${form}
    </div>
`;

SubmitPost('#post', '#postexample', '#cpppost');