function result = mvf(m, k, b, F0, wf, x0, v0)

% ================= PARAMETROS =================
lambda = b/(2*m);
omega = sqrt(k/m);

t = linspace(0, 10, 200);

% ================= RESPUESTA FORZADA =================
A = F0 / sqrt((k - m*wf^2)^2 + (b*wf)^2);
phi = atan2(b*wf, (k - m*wf^2));

xp = A * cos(wf*t - phi);

% (Para este nivel ignoramos transitorio)
x = xp;

% ================= RESULT =================
result.lambda = lambda;
result.omega = omega;

result.F0 = F0;
result.omega_f = wf;

result.A = A;
result.phi = phi;

result.equation = sprintf("x(t) = %.4f*cos(%.4ft - %.4f)", A, wf, phi);

result.t = t;
result.x = x;

% ================= JSON =================
json = jsonencode(result);

fprintf("JSON_START\n");
fprintf("%s\n", json);
fprintf("JSON_END\n");

end