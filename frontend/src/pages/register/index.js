import React, { useState } from "react";
import axios from "axios";
import {
  Card,
  CardContent,
  Typography,
  TextField,
  Button,
  Box,
  CircularProgress,
} from "@mui/material";
import ReusableForm from "../../components/form/reusable-form";
const Register = () => {
  const [userCreatedSuccessfully,setUserCreatedSuccessfully] = useState(false)
  const [isLoading,setLoading]=useState(false)
  const [errorValue,isError]=useState(false)
  async function handleRegister(e) {
    e.preventDefault();
    const data = {
      name: e.target.name.value,
      email: e.target.email.value,
      password: e.target.password.value,
      username: e.target.username.value,
    };
    try {
      isError(false)
      setLoading(true)
      await axios.post("https://localhost:7187/User/CreateUser", data);
      setLoading(false)
      console.log("User registered successfully:", data);
      setUserCreatedSuccessfully(true)
    } catch (error) {
      isError(true)
      console.error("Error registering user:", error);
      setLoading(false)
      setUserCreatedSuccessfully(false)
    }
  }
  const list = [{ id: "username_register", name: "username", label: "Username", type: "type" },
  { id: "name_register", name: "name", label: "Name", type: "type" },
  { id: "email_register", name: "email", label: "Email", type: "email" },
  { id: "password_register", name: "password", label: "Password", type: "password" }]
  return (
    <ReusableForm.Wrapper>
      <ReusableForm.Header
        title="Register"
      />
      <Box
        id="registerForm"
        component="form"
        onSubmit={handleRegister}
        sx={{ display: "flex", flexDirection: "column", gap: 2 }}
      >
        {list.map(x => <ReusableForm.Field {...x} />)}
        <Button
          id="submitBtn_register"
          type="submit"
          variant="contained"
          sx={{
            mt: 2,
            py: 1.5,
            fontWeight: "bold",
            borderRadius: 2,
            textTransform: "none",
          }}
        >
          Create Account
        </Button>
      </Box>
      <ReusableForm.Footer footerText="@ All rights rezerved. We are comunists." />
      <p>{userCreatedSuccessfully==true ? "User created succesfully" : ""}</p>
      <p>{errorValue==true ? "An error has ocured" : ""}</p>
      <div>{isLoading==true ? <CircularProgress/>: <></>}</div>
    </ReusableForm.Wrapper>
  );
};

export default Register;
