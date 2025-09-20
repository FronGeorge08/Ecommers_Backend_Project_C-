import React from "react";
import { TextField, Button, Card, CardContent, Typography, Box, List } from "@mui/material";
import ReusableForm from "../../components/form/reusable-form";
const Login = () => {
  const handleSubmit = (e) => {
    e.preventDefault();
    const data = {
      email: e.target.email_login.value,
      password: e.target.password_login.value,
    };
    console.log("Login Data:", data);
  };
const list=[{id:"email_login",name:"email_login",label:"Email",type:"email"},{id:"password_login",name:"password_login",label:"Password",type:"password"}]
  return (
    <ReusableForm.Wrapper>
      <ReusableForm.Header title={"Login"}/>
          <Box
            id="form_login"
            component="form"
            onSubmit={handleSubmit}
            sx={{ display: "flex", flexDirection: "column", gap: 2 }}
          >
            {list.map(x=><ReusableForm.Field {...x}/>)}
            <ReusableForm.Button button_text={"Login"} type={"submit"}/>
          </Box>
    <ReusableForm.Footer footerText={"We assing, we steal."}/>
    </ReusableForm.Wrapper>
  );
};

export default Login;
