import './Login.css'

export default function Login() {
  return (
    <body>
      <header>
        <div class="topbar">
          <h1 class="logo">Conscea</h1>
        </div>
        <div class="bottombar"></div>
      </header>

      <container class="content">
        <h1>Certificate Site Login</h1>

        <form>
          <div class="logininputs">
            <div class="formSegment">
              <label for="username"> Username </label>
              <input id="username"></input>
            </div>
            <div class="formSegment">
              <label for="password"> Password </label>
              <input type="password" id="password"></input>
            </div>
          </div>
            <button
              class="logins"
              type="submit"
              id="submit_login" >
              Login
            </button>
        </form>
        
        <button class="logins">
          Forgot Password?
        </button>
        </container>

        <footer>
          <div class="bottombar"></div>
          <div class="topbar"></div> 
        </footer>
        
    </body>
  )
}