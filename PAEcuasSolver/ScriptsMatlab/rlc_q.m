function result = rlc_q(L, R, C, E, q0, i0)

% ================= TIEMPO =================
t = linspace(0,10,200);

% ================= MODELO =================
a = L;
b = R;
c = 1/C;

% ================= FORZAMIENTO =================
if isnumeric(E)
    f = @(t) E;
else
    f = @(t) eval(E);
end

% ================= SOLVER =================
result = ode2_core(a, b, c, f, t, q0, i0);

% ================= JSON OUTPUT =================
json = jsonencode(result);

fprintf("JSON_START\n");
fprintf("%s\n", json);
fprintf("JSON_END\n");

end