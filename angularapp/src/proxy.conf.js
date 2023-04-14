const PROXY_CONFIG = [
  {
    context: [
      "/weatherforecast",
      "/users",
      "/account/login",
      "/account/register",
      '/logins'
    ],
    target: "https://localhost:7017",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
