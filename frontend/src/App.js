import logo from './logo.svg';
import './App.css';

function App() {
  return (
    <div className="App">
       <div class="card">
<h2>Register</h2>
<form>
  <div class="form-group">
    <label for="username">Username</label>
    <input type="text" id="username" name="username" placeholder="Enter your username" required></input>
  </div>
  <div class="form-group">
    <label for="fullname">Full Name</label>
    <input type="text" id="fullname" name="fullname" placeholder="Enter your full name" required></input>
  </div>
  <div class="form-group">
    <label for="email">Email</label>
    <input type="email" id="email" name="email" placeholder="Enter your email" required></input>
  </div>
  <div class="form-group">
    <label for="password">Password</label>
    <input type="password" id="password" name="password" placeholder="Enter your password" required></input>
  </div>
  <button type="submit" class="btn">Create Account</button>
</form>
</div>
    </div>
  );
}

export default App;
